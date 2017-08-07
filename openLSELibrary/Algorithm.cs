using System;
using System.Collections.Generic;
using System.Linq;
using SynchrophasorAnalytics.Networks;
using SynchrophasorAnalytics.Measurements;
using GSF.Configuration;
using GSF.IO;
using ECAClientFramework;
using ECAClientUtilities.API;
using openLSE.Model.LSE;

namespace openLSE
{
    public static class Algorithm
    {
        #region [ Private Members ]

        private static Network m_network;
        private static int m_startDelay;
        private static string m_internalErrorMessage;
        private static ConfigurationFile m_serviceConfiguration;
        private static CategorizedSettingsElementCollection m_settings;
        private static string m_overridePhaseConfiguration;
        private static PhaseSelection m_phaseSelection;
        private static int m_frameIndex;

        #endregion

        #region [ Properties ] 

        /// <summary>
        /// The hook back into the openECA API
        /// </summary>
        public static Hub API { get; set; }

        /// <summary>
        /// The current configuration file for the openLSE Service.
        /// </summary>
        public static ConfigurationFile ServiceConfiguration
        {
            get
            {
                if (m_serviceConfiguration == null)
                {
                    m_serviceConfiguration = ConfigurationFile.Current;

                }
                return m_serviceConfiguration;
            }
        }

        /// <summary>
        /// The subset of global configuration for system.
        /// </summary>
        public static CategorizedSettingsElementCollection Settings
        {
            get
            {
                if (m_settings == null)
                {
                    m_settings = ServiceConfiguration.Settings["systemSettings"];
                }
                return m_settings;
            }
        }

        /// <summary>
        /// A boolean flag that indicates whether to override the phase configuration in the network model.
        /// </summary>
        public static bool OverridePhaseConfiguration
        {
            get
            {
                string overridePhaseConfiguration = Settings["OverridePhaseConfiguration"].Value;
                return Convert.ToBoolean(overridePhaseConfiguration);
            }
        }

        /// <summary>
        /// Dictates whether the LSE behaves as a 3 phase LSE or positive sequence LSE
        /// </summary>
        public static PhaseSelection PhaseConfiguration
        {
            get
            {
                if (Settings["PhaseConfiguration"].Value == "ThreePhase")
                {
                    return PhaseSelection.ThreePhase;
                }
                return PhaseSelection.PositiveSequence;
            }
        }

        /// <summary>
        /// The absolute path to the file that contains the network model.
        /// </summary>
        public static string NetworkModelAbsolutePath
        {
            get
            {
                return FilePath.GetAbsolutePath(Settings["NetworkModelAbsolutePath"].Value);
            }
        }

        #endregion

        #region [ Constructor ]

        static Algorithm()
        {
            RefreshModel();
            m_frameIndex = 0;
        }

        #endregion

        #region [ Output Definition and Creation ]

        /// <summary>
        /// Contains the definition for the output data structure and output metadata as well as the 
        /// function to generate new Output objects.
        /// </summary>
        internal class Output
        {
            public EstimatorOutput OutputData = new EstimatorOutput();
            public _EstimatorOutputMeta OutputMeta = new _EstimatorOutputMeta();
            public static Func<Output> CreateNew { get; set; } = () => new Output();
        }

        #endregion

        #region [ Update System Settings ]

        /// <summary>
        /// Provides local versions of system settings for the test harness.
        /// </summary>
        public static void UpdateSystemSettings()
        {
            SystemSettings.InputMapping = "Input";
            SystemSettings.OutputMapping = "Output";
            SystemSettings.ConnectionString = @"server=localhost:6190; interface=0.0.0.0";
            SystemSettings.FramesPerSecond = 30;
            SystemSettings.LagTime = 3;
            SystemSettings.LeadTime = 1;
        }

        #endregion

        #region [ Algorithm Execution ]

        internal static Output Execute(Input inputData, _InputMeta inputMeta)
        {
            Output output = Output.CreateNew();
            m_frameIndex += 1;

            try
            {
                if (m_network == null || m_network.Model == null)
                {
                    MainWindow.WriteError(new NullReferenceException($"Network or NetworkModel is null"));
                }
                else
                {
                    ClearMeasurements();
                    MapInput(inputData, inputMeta);
                    AcknowledgeMeasurements();
                    ExecuteObservabilityAnalysis();
                    ComputeSystemState();
                    PostProcessSystemState();
                    MapOutput(output);
                }
            }
            catch (Exception ex)
            {
                // Display exceptions to the main window
                MainWindow.WriteError(new InvalidOperationException($"Algorithm exception: {ex.Message}", ex));
            }

            return output;
        }

        #endregion

        #region [ LSE API ] 

        #region [ Input Mapping ]

        /// <summary>
        /// Maps the incoming voltage phasors to their appropriate nodes in the network model.
        /// </summary>
        /// <param name="inputData">The frame of input data as provided by the openECA.</param>
        /// <param name="inputMeta">The metadata for the frame of input data as provided by the openECA</param>
        private static void MapVoltagePhasorInput(Input inputData, _InputMeta inputMeta)
        {
            // Add the measurements to the model here
            // m_network.Model.InputKeyValuePairs.Add(angleKey, phasor.Angle);
            for (int i = 0; i < inputMeta.VoltagePhasors.Phasors.Length; i++)
            {

                Guid magnitudeKey = inputMeta.VoltagePhasors.Phasors[i].Magnitude.ID;
                Guid angleKey = inputMeta.VoltagePhasors.Phasors[i].Angle.ID;
                double magnitude = inputData.VoltagePhasors.Phasors[i].Magnitude;
                double angle = inputData.VoltagePhasors.Phasors[i].Angle;
                if (magnitudeKey != Guid.Empty)
                {
                    m_network.Model.InputKeyValuePairs.Add(magnitudeKey.ToString(), magnitude);
                }
                if (angleKey != Guid.Empty)
                {
                    m_network.Model.InputKeyValuePairs.Add(angleKey.ToString(), angle);
                }
            }
        }

        /// <summary>
        /// Maps the incoming current phasors to their appropriate series and shunt elements in the network model.
        /// </summary>
        /// <param name="inputData">The frame of input data as provided by the openECA.</param>
        /// <param name="inputMeta">The metadata for the frame of input data as provided by the openECA</param>
        private static void MapCurrentPhasorInput(Input inputData, _InputMeta inputMeta)
        {
            // Add the measurements to the model here
            // m_network.Model.InputKeyValuePairs.Add(angleKey, phasor.Angle);
            for (int i = 0; i < inputMeta.VoltagePhasors.Phasors.Length; i++)
            {
                Guid magnitudeKey = inputMeta.CurrentPhasors.Phasors[i].Magnitude.ID;
                Guid angleKey = inputMeta.CurrentPhasors.Phasors[i].Angle.ID;
                double magnitude = inputData.CurrentPhasors.Phasors[i].Magnitude;
                double angle = inputData.CurrentPhasors.Phasors[i].Angle;
                if (magnitudeKey != Guid.Empty)
                {
                    m_network.Model.InputKeyValuePairs.Add(magnitudeKey.ToString(), magnitude);
                }
                if (angleKey != Guid.Empty)
                {
                    m_network.Model.InputKeyValuePairs.Add(angleKey.ToString(), angle);
                }
            }
        }

        /// <summary>
        /// Maps the incoming PMU status flags to their appropriate measurements in the network model.
        /// </summary>
        /// <param name="inputData">The frame of input data as provided by the openECA.</param>
        /// <param name="inputMeta">The metadata for the frame of input data as provided by the openECA</param>
        private static void MapStatusWordInput(Input inputData, _InputMeta inputMeta)
        {
            // Add the measurements to the model here
            // m_network.Model.InputKeyValuePairs.Add(angleKey, phasor.Angle);
            for (int i = 0; i < inputMeta.StatusWords.Values.Length; i++)
            {
                Guid key = inputMeta.StatusWords.Values[i].ID;
                double value = inputData.StatusWords.Values[i];
                if (key != Guid.Empty)
                {
                    m_network.Model.InputKeyValuePairs.Add(key.ToString(), value);
                }
            }
        }

        /// <summary>
        /// Maps the incoming digital values to their appropriate measurements in the network model.
        /// </summary>
        /// <param name="inputData">The frame of input data as provided by the openECA.</param>
        /// <param name="inputMeta">The metadata for the frame of input data as provided by the openECA</param>
        private static void MapDigitalsInput(Input inputData, _InputMeta inputMeta)
        {
            for (int i = 0; i < inputMeta.Digitals.Values.Length; i++)
            {
                Guid key = inputMeta.Digitals.Values[i].ID;
                double value = inputData.Digitals.Values[i];
                if (key != Guid.Empty)
                {
                    m_network.Model.InputKeyValuePairs.Add(key.ToString(), value);
                }
            }
        }

        #endregion

        #region [ Operations ]

        /// <summary>
        /// Loads or reloads the specified network model
        /// </summary>
        public static void RefreshModel()
        {
            try
            {
                m_network = Network.DeserializeFromXml(NetworkModelAbsolutePath);
                if (m_network != null)
                {
                    m_network.Initialize();
                    if (OverridePhaseConfiguration)
                    {
                        m_network.Model.PhaseConfiguration = PhaseConfiguration;
                    }
                    m_network.Model.AcceptsEstimates = false;
                    m_network.Model.AcceptsMeasurements = true;
                    m_network.SerializeData(true);
                    MainWindow.WriteMessage("Successfully read network model file...");
                }
            }
            catch (Exception ex)
            {
                // Display exceptions to the main window
                MainWindow.WriteMessage($"Failed to deserialize the network model from: {NetworkModelAbsolutePath}");
                MainWindow.WriteMessage("Network is null.");
            }
        }

        /// <summary>
        /// Clears the last frame of measurements from the LSE and prepares it to receive the next frame.
        /// </summary>
        private static void ClearMeasurements()
        {
            // Clear the measurements from the model in preparation

            m_network.Model.InputKeyValuePairs.Clear();
            m_network.Model.ClearValues();
        }

        private static void MapInput(Input inputData, _InputMeta inputMeta)
        {
            MapVoltagePhasorInput(inputData, inputMeta);
            MapCurrentPhasorInput(inputData, inputMeta);
            MapStatusWordInput(inputData, inputMeta);
            MapDigitalsInput(inputData, inputMeta);
        }

        /// <summary>
        /// Tells the LSE that all available measurements have been processed and that it is now OK to begin the state estimation process
        /// </summary>
        private static void AcknowledgeMeasurements()
        {
            m_network.Model.OnNewMeasurements();
        }

        /// <summary>
        /// Executes the prerequisite observability analysis. 
        /// </summary>
        private static void ExecuteObservabilityAnalysis()
        {
            m_network.RunNetworkReconstructionCheck();
            if (m_network.HasChangedSincePreviousFrame)
            {
                m_network.Model.DetermineActiveCurrentFlows();
                m_network.Model.DetermineActiveCurrentInjections();
            }

            if (m_network.HasChangedSincePreviousFrame)
            {
                m_network.Model.ResolveToObservedBuses();
                m_network.Model.ResolveToSingleFlowBranches();

            }
        }

        /// <summary>
        /// Computes the system state.
        /// </summary>
        private static void ComputeSystemState()
        {
            m_network.ComputeSystemState();
        }

        private static void PostProcessSystemState()
        {
            m_network.Model.ComputeEstimatedCurrentFlows();
        }

        private static void MapOutput(Output output)
        {
            MapVoltageEstimateOutput(output);
            MapCurrentEstimateOutput(output);
            //MapVoltageResidualOutput(output);
            //MapCurrentFlowResidualOutput(output);
            //MapCircuitBreakerStatusOutput(output);
            MapPerformanceMetrics(output);
            //MapTopologyProfilingOutput(output);
            MapMeasurementValidationFlagOutput(output);
        }

        #endregion

        #region [ Status Messages ]
        // Some methods for getting text based status should go here.
        #endregion

        #region [ Output Mapping ]

        /// <summary>
        /// Maps the outgoing measurement validation flags to their appropriate output measurements for openECA.
        /// </summary>
        /// <param name="output">The output data frame as provided by openECA.</param>
        private static void MapMeasurementValidationFlagOutput(Output output)
        {
            Dictionary<string, OutputMeasurement> validationFlags = m_network.Model.MeasurementValidationFlagOutput.ToDictionary(x => x.Key, x => x);

            for (int i = 0; i < output.OutputMeta.MeasurementValidationFlags.Length; i++)
            {
                string key = output.OutputMeta.MeasurementValidationFlags[i].ID.ToString();
                OutputMeasurement flag = null;
                validationFlags.TryGetValue(key, out flag);
                if (flag != null)
                {
                    output.OutputData.MeasurementValidationFlags[i] = flag.Value;
                }
            }
        }

        /// <summary>
        /// Maps the outgoing voltage phasor estimates to their appropriate output measurements for openECA.
        /// </summary>
        /// <param name="output">The output data frame as provided by openECA.</param>
        private static void MapVoltageEstimateOutput(Output output)
        {
            Dictionary<string, OutputMeasurement> voltageEstimates = m_network.Model.StateEstimateOutput.ToDictionary(x => x.Key, x => x);

            for (int i = 0; i < output.OutputMeta.VoltageMagnitudeEstimates.Length; i++)
            {
                string magnitudeKey = output.OutputMeta.VoltageMagnitudeEstimates[i].ID.ToString();
                OutputMeasurement magnitude = null;
                voltageEstimates.TryGetValue(magnitudeKey, out magnitude);
                if (magnitude != null)
                {
                    output.OutputData.VoltageMagnitudeEstimates[i] = magnitude.Value;
                }

                string angleKey = output.OutputMeta.VoltageAngleEstimates[i].ID.ToString();
                OutputMeasurement angle = null;
                voltageEstimates.TryGetValue(angleKey, out angle);
                if (angle != null)
                {
                    output.OutputData.VoltageAngleEstimates[i] = angle.Value;
                }
            }
        }

        /// <summary>
        /// Maps the outgoing current phasor estimates to their appropriate output measurements for openECA.
        /// </summary>
        /// <param name="output">The output data frame as provided by openECA.</param>
        private static void MapCurrentEstimateOutput(Output output)
        {
            Dictionary<string, OutputMeasurement> currentFlowEstimates = m_network.Model.CurrentFlowEstimateOutput.ToDictionary(x => x.Key, x => x);

            for (int i = 0; i < output.OutputMeta.CurrentFlowMagnitudeEstimates.Length; i++)
            {
                string magnitudeKey = output.OutputMeta.CurrentFlowMagnitudeEstimates[i].ID.ToString();
                OutputMeasurement magnitude = null;
                currentFlowEstimates.TryGetValue(magnitudeKey, out magnitude);
                if (magnitude != null)
                {
                    output.OutputData.CurrentFlowMagnitudeEstimates[i] = magnitude.Value;
                }

                string angleKey = output.OutputMeta.CurrentFlowAngleEstimates[i].ID.ToString();
                OutputMeasurement angle = null;
                currentFlowEstimates.TryGetValue(angleKey, out angle);
                if (angle != null)
                {
                    output.OutputData.CurrentFlowAngleEstimates[i] = angle.Value;
                }
            }
        }

        //private static void MapCurrentInjectionEstimateOutput(Output output)
        //{
        //    Dictionary<string, OutputMeasurement> currentInjectionEstimates = m_network.Model.CurrentInjectionEstimateOutput.ToDictionary(x => x.Key, x => x);

        //    // Currently no current injection estimate in LSE OUTPUT.
        //}

        private static void MapVoltageResidualOutput(Output output)
        {
            Dictionary<string, OutputMeasurement> voltageResiduals = m_network.Model.VoltageResidualOutput.ToDictionary(x => x.Key, x => x);

            for (int i = 0; i < output.OutputMeta.VoltageMagnitudeResiduals.Length; i++)
            {
                string magnitudeKey = output.OutputMeta.VoltageMagnitudeResiduals[i].ID.ToString();
                OutputMeasurement magnitude = null;
                voltageResiduals.TryGetValue(magnitudeKey, out magnitude);
                if (magnitude != null)
                {
                    output.OutputData.VoltageMagnitudeResiduals[i] = magnitude.Value;
                }

                string angleKey = output.OutputMeta.VoltageAngleResiduals[i].ID.ToString();
                OutputMeasurement angle = null;
                voltageResiduals.TryGetValue(angleKey, out angle);
                if (angle != null)
                {
                    output.OutputData.VoltageAngleResiduals[i] = angle.Value;
                }
            }
        }

        private static void MapCurrentFlowResidualOutput(Output output)
        {
            Dictionary<string, OutputMeasurement> currentFlowResiduals = m_network.Model.CurrentResidualOutput.ToDictionary(x => x.Key, x => x);

            for (int i = 0; i < output.OutputMeta.CurrentFlowMagnitudeResiduals.Length; i++)
            {
                string magnitudeKey = output.OutputMeta.CurrentFlowMagnitudeResiduals[i].ID.ToString();
                OutputMeasurement magnitude = null;
                currentFlowResiduals.TryGetValue(magnitudeKey, out magnitude);
                if (magnitude != null)
                {
                    output.OutputData.CurrentFlowMagnitudeResiduals[i] = magnitude.Value;
                }

                string angleKey = output.OutputMeta.CurrentFlowAngleResiduals[i].ID.ToString();
                OutputMeasurement angle = null;
                currentFlowResiduals.TryGetValue(angleKey, out angle);
                if (angle != null)
                {
                    output.OutputData.CurrentFlowAngleResiduals[i] = angle.Value;
                }
            }
        }

        private static void MapCircuitBreakerStatusOutput(Output output)
        {
            Dictionary<string, OutputMeasurement> circuitBreakerStatuses = m_network.Model.CircuitBreakerStatusOutput.ToDictionary(x => x.Key, x => x);

            for (int i = 0; i < output.OutputMeta.CircuitBreakerStatuses.Length; i++)
            {
                string key = output.OutputMeta.CircuitBreakerStatuses[i].ID.ToString();
                OutputMeasurement status = null;
                circuitBreakerStatuses.TryGetValue(key, out status);
                if (status != null)
                {
                    output.OutputData.CircuitBreakerStatuses[i] = status.Value;
                }
            }
        }

        //private static void MapSwitchStatusOutput(Output output)
        //{
        //    Dictionary<string, OutputMeasurement> switchStatuses = m_network.Model.SwitchStatusOutput.ToDictionary(x => x.Key, x => x);

        //    for (int i = 0; i < output.OutputMeta.CircuitBreakerStatuses.Length; i++)
        //    {
        //        string key = output.OutputMeta.CircuitBreakerStatuses[i].ID.ToString();
        //        OutputMeasurement status = null;
        //        switchStatuses.TryGetValue(key, out status);
        //        if (status != null)
        //        {
        //            output.OutputData.CircuitBreakerStatuses[i] = status.Value;
        //        }
        //    }
        //}

        private static void MapTopologyProfilingOutput(Output output)
        {
            Dictionary<string, OutputMeasurement> topologyProfiling = m_network.Model.TopologyProfilingOutput.ToDictionary(x => x.Key, x => x);

            for (int i = 0; i < output.OutputMeta.TopologyProfilingData.Length; i++)
            {
                string key = output.OutputMeta.TopologyProfilingData[i].ID.ToString();
                OutputMeasurement data = null;
                topologyProfiling.TryGetValue(key, out data);
                if (data != null)
                {
                    output.OutputData.TopologyProfilingData[i] = data.Value;
                }
            }
        }

        /// <summary>
        /// Maps the outgoing LSE performance metrics to their appropriate output measurements for openECA.
        /// </summary>
        /// <param name="output">The output data frame as provided by openECA.</param>
        private static void MapPerformanceMetrics(Output output)
        {
            output.OutputData.PerformanceMetrics.ActiveVoltagesCount = m_network.Model.ActiveVoltages.Count;
            output.OutputData.PerformanceMetrics.ActiveCurrentFlowsCount = m_network.Model.ActiveCurrentFlows.Count;
            output.OutputData.PerformanceMetrics.ActiveCurrentInjectionsCount = m_network.Model.ActiveCurrentInjections.Count;
            output.OutputData.PerformanceMetrics.ObservedBusCount = m_network.Model.ObservedBusses.Count;
        }

        #endregion

        #endregion
    }
}
