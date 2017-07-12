// COMPILER GENERATED CODE
// THIS WILL BE OVERWRITTEN AT EACH GENERATION
// EDIT AT YOUR OWN RISK

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using ECAClientFramework;
using ECAClientUtilities;
using ECACommonUtilities;
using ECACommonUtilities.Model;
using GSF.TimeSeries;

namespace openLSE.Model
{
    [CompilerGenerated]
    public class Unmapper : UnmapperBase
    {
        #region [ Constructors ]

        public Unmapper(Framework framework, MappingCompiler mappingCompiler)
            : base(framework, mappingCompiler, SystemSettings.OutputMapping)
        {
            Algorithm.Output.CreateNew = () => new Algorithm.Output()
            {
                OutputData = FillOutputData(),
                OutputMeta = FillOutputMeta()
            };
        }

        #endregion

        #region [ Methods ]

        public openLSE.Model.LSE.EstimatorOutput FillOutputData()
        {
            TypeMapping outputMapping = MappingCompiler.GetTypeMapping(OutputMapping);
            Reset();
            return FillLSEEstimatorOutput(outputMapping);
        }

        public openLSE.Model.LSE._EstimatorOutputMeta FillOutputMeta()
        {
            TypeMapping outputMeta = MappingCompiler.GetTypeMapping(OutputMapping);
            Reset();
            return FillLSE_EstimatorOutputMeta(outputMeta);
        }

        public IEnumerable<IMeasurement> Unmap(openLSE.Model.LSE.EstimatorOutput outputData, openLSE.Model.LSE._EstimatorOutputMeta outputMeta)
        {
            List<IMeasurement> measurements = new List<IMeasurement>();
            TypeMapping outputMapping = MappingCompiler.GetTypeMapping(OutputMapping);

            CollectFromLSEEstimatorOutput(measurements, outputMapping, outputData, outputMeta);

            return measurements;
        }

        private openLSE.Model.LSE.EstimatorOutput FillLSEEstimatorOutput(TypeMapping typeMapping)
        {
            Dictionary<string, FieldMapping> fieldLookup = typeMapping.FieldMappings.ToDictionary(mapping => mapping.Field.Identifier);
            openLSE.Model.LSE.EstimatorOutput obj = new openLSE.Model.LSE.EstimatorOutput();

            {
                // Initialize array for "CircuitBreakerStatuses" field
                ArrayMapping arrayMapping = (ArrayMapping)fieldLookup["CircuitBreakerStatuses"];
                obj.CircuitBreakerStatuses = new double[GetArrayMeasurementCount(arrayMapping)];
            }

            {
                // Initialize array for "TopologyProfilingData" field
                ArrayMapping arrayMapping = (ArrayMapping)fieldLookup["TopologyProfilingData"];
                obj.TopologyProfilingData = new double[GetArrayMeasurementCount(arrayMapping)];
            }

            {
                // Initialize array for "MeasurementValidationFlags" field
                ArrayMapping arrayMapping = (ArrayMapping)fieldLookup["MeasurementValidationFlags"];
                obj.MeasurementValidationFlags = new double[GetArrayMeasurementCount(arrayMapping)];
            }

            {
                // Initialize array for "VoltageMagnitudeEstimates" field
                ArrayMapping arrayMapping = (ArrayMapping)fieldLookup["VoltageMagnitudeEstimates"];
                obj.VoltageMagnitudeEstimates = new double[GetArrayMeasurementCount(arrayMapping)];
            }

            {
                // Initialize array for "VoltageAngleEstimates" field
                ArrayMapping arrayMapping = (ArrayMapping)fieldLookup["VoltageAngleEstimates"];
                obj.VoltageAngleEstimates = new double[GetArrayMeasurementCount(arrayMapping)];
            }

            {
                // Initialize array for "VoltageMagnitudeResiduals" field
                ArrayMapping arrayMapping = (ArrayMapping)fieldLookup["VoltageMagnitudeResiduals"];
                obj.VoltageMagnitudeResiduals = new double[GetArrayMeasurementCount(arrayMapping)];
            }

            {
                // Initialize array for "VoltageAngleResiduals" field
                ArrayMapping arrayMapping = (ArrayMapping)fieldLookup["VoltageAngleResiduals"];
                obj.VoltageAngleResiduals = new double[GetArrayMeasurementCount(arrayMapping)];
            }

            {
                // Initialize array for "CurrentFlowMagnitudeEstimates" field
                ArrayMapping arrayMapping = (ArrayMapping)fieldLookup["CurrentFlowMagnitudeEstimates"];
                obj.CurrentFlowMagnitudeEstimates = new double[GetArrayMeasurementCount(arrayMapping)];
            }

            {
                // Initialize array for "CurrentFlowAngleEstimates" field
                ArrayMapping arrayMapping = (ArrayMapping)fieldLookup["CurrentFlowAngleEstimates"];
                obj.CurrentFlowAngleEstimates = new double[GetArrayMeasurementCount(arrayMapping)];
            }

            {
                // Initialize array for "CurrentFlowMagnitudeResiduals" field
                ArrayMapping arrayMapping = (ArrayMapping)fieldLookup["CurrentFlowMagnitudeResiduals"];
                obj.CurrentFlowMagnitudeResiduals = new double[GetArrayMeasurementCount(arrayMapping)];
            }

            {
                // Initialize array for "CurrentFlowAngleResiduals" field
                ArrayMapping arrayMapping = (ArrayMapping)fieldLookup["CurrentFlowAngleResiduals"];
                obj.CurrentFlowAngleResiduals = new double[GetArrayMeasurementCount(arrayMapping)];
            }

            {
                // Initialize openLSE.Model.LSE.PerformanceMetrics UDT for "PerformanceMetrics" field
                FieldMapping fieldMapping = fieldLookup["PerformanceMetrics"];
                TypeMapping nestedMapping = GetTypeMapping(fieldMapping);

                PushRelativeFrameTime(fieldMapping);
                obj.PerformanceMetrics = this.FillLSEPerformanceMetrics(nestedMapping);
                PopRelativeFrameTime(fieldMapping);
            }

            return obj;
        }

        private openLSE.Model.LSE._EstimatorOutputMeta FillLSE_EstimatorOutputMeta(TypeMapping typeMapping)
        {
            Dictionary<string, FieldMapping> fieldLookup = typeMapping.FieldMappings.ToDictionary(mapping => mapping.Field.Identifier);
            openLSE.Model.LSE._EstimatorOutputMeta obj = new openLSE.Model.LSE._EstimatorOutputMeta();

            {
                // Initialize array for "CircuitBreakerStatuses" field
                ArrayMapping arrayMapping = (ArrayMapping)fieldLookup["CircuitBreakerStatuses"];
                obj.CircuitBreakerStatuses = CreateMetaValues(arrayMapping).ToArray();
            }

            {
                // Initialize array for "TopologyProfilingData" field
                ArrayMapping arrayMapping = (ArrayMapping)fieldLookup["TopologyProfilingData"];
                obj.TopologyProfilingData = CreateMetaValues(arrayMapping).ToArray();
            }

            {
                // Initialize array for "MeasurementValidationFlags" field
                ArrayMapping arrayMapping = (ArrayMapping)fieldLookup["MeasurementValidationFlags"];
                obj.MeasurementValidationFlags = CreateMetaValues(arrayMapping).ToArray();
            }

            {
                // Initialize array for "VoltageMagnitudeEstimates" field
                ArrayMapping arrayMapping = (ArrayMapping)fieldLookup["VoltageMagnitudeEstimates"];
                obj.VoltageMagnitudeEstimates = CreateMetaValues(arrayMapping).ToArray();
            }

            {
                // Initialize array for "VoltageAngleEstimates" field
                ArrayMapping arrayMapping = (ArrayMapping)fieldLookup["VoltageAngleEstimates"];
                obj.VoltageAngleEstimates = CreateMetaValues(arrayMapping).ToArray();
            }

            {
                // Initialize array for "VoltageMagnitudeResiduals" field
                ArrayMapping arrayMapping = (ArrayMapping)fieldLookup["VoltageMagnitudeResiduals"];
                obj.VoltageMagnitudeResiduals = CreateMetaValues(arrayMapping).ToArray();
            }

            {
                // Initialize array for "VoltageAngleResiduals" field
                ArrayMapping arrayMapping = (ArrayMapping)fieldLookup["VoltageAngleResiduals"];
                obj.VoltageAngleResiduals = CreateMetaValues(arrayMapping).ToArray();
            }

            {
                // Initialize array for "CurrentFlowMagnitudeEstimates" field
                ArrayMapping arrayMapping = (ArrayMapping)fieldLookup["CurrentFlowMagnitudeEstimates"];
                obj.CurrentFlowMagnitudeEstimates = CreateMetaValues(arrayMapping).ToArray();
            }

            {
                // Initialize array for "CurrentFlowAngleEstimates" field
                ArrayMapping arrayMapping = (ArrayMapping)fieldLookup["CurrentFlowAngleEstimates"];
                obj.CurrentFlowAngleEstimates = CreateMetaValues(arrayMapping).ToArray();
            }

            {
                // Initialize array for "CurrentFlowMagnitudeResiduals" field
                ArrayMapping arrayMapping = (ArrayMapping)fieldLookup["CurrentFlowMagnitudeResiduals"];
                obj.CurrentFlowMagnitudeResiduals = CreateMetaValues(arrayMapping).ToArray();
            }

            {
                // Initialize array for "CurrentFlowAngleResiduals" field
                ArrayMapping arrayMapping = (ArrayMapping)fieldLookup["CurrentFlowAngleResiduals"];
                obj.CurrentFlowAngleResiduals = CreateMetaValues(arrayMapping).ToArray();
            }

            {
                // Initialize openLSE.Model.LSE._PerformanceMetricsMeta UDT for "PerformanceMetrics" field
                FieldMapping fieldMapping = fieldLookup["PerformanceMetrics"];
                TypeMapping nestedMapping = GetTypeMapping(fieldMapping);

                PushRelativeFrameTime(fieldMapping);
                obj.PerformanceMetrics = this.FillLSE_PerformanceMetricsMeta(nestedMapping);
                PopRelativeFrameTime(fieldMapping);
            }

            return obj;
        }

        private openLSE.Model.LSE.PerformanceMetrics FillLSEPerformanceMetrics(TypeMapping typeMapping)
        {
            Dictionary<string, FieldMapping> fieldLookup = typeMapping.FieldMappings.ToDictionary(mapping => mapping.Field.Identifier);
            openLSE.Model.LSE.PerformanceMetrics obj = new openLSE.Model.LSE.PerformanceMetrics();

            {
                // We don't need to do anything, but we burn a key index to keep our
                // array index in sync with where we are in the data structure
                BurnKeyIndex();
            }

            {
                // We don't need to do anything, but we burn a key index to keep our
                // array index in sync with where we are in the data structure
                BurnKeyIndex();
            }

            {
                // We don't need to do anything, but we burn a key index to keep our
                // array index in sync with where we are in the data structure
                BurnKeyIndex();
            }

            {
                // We don't need to do anything, but we burn a key index to keep our
                // array index in sync with where we are in the data structure
                BurnKeyIndex();
            }

            {
                // We don't need to do anything, but we burn a key index to keep our
                // array index in sync with where we are in the data structure
                BurnKeyIndex();
            }

            {
                // We don't need to do anything, but we burn a key index to keep our
                // array index in sync with where we are in the data structure
                BurnKeyIndex();
            }

            {
                // We don't need to do anything, but we burn a key index to keep our
                // array index in sync with where we are in the data structure
                BurnKeyIndex();
            }

            {
                // We don't need to do anything, but we burn a key index to keep our
                // array index in sync with where we are in the data structure
                BurnKeyIndex();
            }

            {
                // We don't need to do anything, but we burn a key index to keep our
                // array index in sync with where we are in the data structure
                BurnKeyIndex();
            }

            {
                // We don't need to do anything, but we burn a key index to keep our
                // array index in sync with where we are in the data structure
                BurnKeyIndex();
            }

            {
                // We don't need to do anything, but we burn a key index to keep our
                // array index in sync with where we are in the data structure
                BurnKeyIndex();
            }

            {
                // We don't need to do anything, but we burn a key index to keep our
                // array index in sync with where we are in the data structure
                BurnKeyIndex();
            }

            {
                // We don't need to do anything, but we burn a key index to keep our
                // array index in sync with where we are in the data structure
                BurnKeyIndex();
            }

            return obj;
        }

        private openLSE.Model.LSE._PerformanceMetricsMeta FillLSE_PerformanceMetricsMeta(TypeMapping typeMapping)
        {
            Dictionary<string, FieldMapping> fieldLookup = typeMapping.FieldMappings.ToDictionary(mapping => mapping.Field.Identifier);
            openLSE.Model.LSE._PerformanceMetricsMeta obj = new openLSE.Model.LSE._PerformanceMetricsMeta();

            {
                // Initialize meta value structure to "ActiveVoltagesCount" field
                FieldMapping fieldMapping = fieldLookup["ActiveVoltagesCount"];
                obj.ActiveVoltagesCount = CreateMetaValues(fieldMapping);
            }

            {
                // Initialize meta value structure to "ActiveCurrentFlowsCount" field
                FieldMapping fieldMapping = fieldLookup["ActiveCurrentFlowsCount"];
                obj.ActiveCurrentFlowsCount = CreateMetaValues(fieldMapping);
            }

            {
                // Initialize meta value structure to "ActiveCurrentInjectionsCount" field
                FieldMapping fieldMapping = fieldLookup["ActiveCurrentInjectionsCount"];
                obj.ActiveCurrentInjectionsCount = CreateMetaValues(fieldMapping);
            }

            {
                // Initialize meta value structure to "RefreshTime" field
                FieldMapping fieldMapping = fieldLookup["RefreshTime"];
                obj.RefreshTime = CreateMetaValues(fieldMapping);
            }

            {
                // Initialize meta value structure to "ParsingTime" field
                FieldMapping fieldMapping = fieldLookup["ParsingTime"];
                obj.ParsingTime = CreateMetaValues(fieldMapping);
            }

            {
                // Initialize meta value structure to "MeasurementMappingTime" field
                FieldMapping fieldMapping = fieldLookup["MeasurementMappingTime"];
                obj.MeasurementMappingTime = CreateMetaValues(fieldMapping);
            }

            {
                // Initialize meta value structure to "ActiveCurrentDeterminationTime" field
                FieldMapping fieldMapping = fieldLookup["ActiveCurrentDeterminationTime"];
                obj.ActiveCurrentDeterminationTime = CreateMetaValues(fieldMapping);
            }

            {
                // Initialize meta value structure to "ObservabilityAnalysisTime" field
                FieldMapping fieldMapping = fieldLookup["ObservabilityAnalysisTime"];
                obj.ObservabilityAnalysisTime = CreateMetaValues(fieldMapping);
            }

            {
                // Initialize meta value structure to "StateComputationTime" field
                FieldMapping fieldMapping = fieldLookup["StateComputationTime"];
                obj.StateComputationTime = CreateMetaValues(fieldMapping);
            }

            {
                // Initialize meta value structure to "ObservedBusCount" field
                FieldMapping fieldMapping = fieldLookup["ObservedBusCount"];
                obj.ObservedBusCount = CreateMetaValues(fieldMapping);
            }

            {
                // Initialize meta value structure to "OutputPreparationTime" field
                FieldMapping fieldMapping = fieldLookup["OutputPreparationTime"];
                obj.OutputPreparationTime = CreateMetaValues(fieldMapping);
            }

            {
                // Initialize meta value structure to "TotalTimeInMilliseconds" field
                FieldMapping fieldMapping = fieldLookup["TotalTimeInMilliseconds"];
                obj.TotalTimeInMilliseconds = CreateMetaValues(fieldMapping);
            }

            {
                // Initialize meta value structure to "TotalTimeInTicks" field
                FieldMapping fieldMapping = fieldLookup["TotalTimeInTicks"];
                obj.TotalTimeInTicks = CreateMetaValues(fieldMapping);
            }

            return obj;
        }

        private void CollectFromLSEEstimatorOutput(List<IMeasurement> measurements, TypeMapping typeMapping, openLSE.Model.LSE.EstimatorOutput data, openLSE.Model.LSE._EstimatorOutputMeta meta)
        {
            Dictionary<string, FieldMapping> fieldLookup = typeMapping.FieldMappings.ToDictionary(mapping => mapping.Field.Identifier);

            {
                // Convert values from array in "CircuitBreakerStatuses" field to measurements
                ArrayMapping arrayMapping = (ArrayMapping)fieldLookup["CircuitBreakerStatuses"];
                int dataLength = data.CircuitBreakerStatuses.Length;
                int metaLength = meta.CircuitBreakerStatuses.Length;

                if (dataLength != metaLength)
                    throw new InvalidOperationException($"Values array length ({dataLength}) and MetaValues array length ({metaLength}) for field \"CircuitBreakerStatuses\" must be the same.");

                for (int i = 0; i < dataLength; i++)
                {
                    IMeasurement measurement = MakeMeasurement(meta.CircuitBreakerStatuses[i], (double)data.CircuitBreakerStatuses[i]);
                    measurements.Add(measurement);
                }
            }

            {
                // Convert values from array in "TopologyProfilingData" field to measurements
                ArrayMapping arrayMapping = (ArrayMapping)fieldLookup["TopologyProfilingData"];
                int dataLength = data.TopologyProfilingData.Length;
                int metaLength = meta.TopologyProfilingData.Length;

                if (dataLength != metaLength)
                    throw new InvalidOperationException($"Values array length ({dataLength}) and MetaValues array length ({metaLength}) for field \"TopologyProfilingData\" must be the same.");

                for (int i = 0; i < dataLength; i++)
                {
                    IMeasurement measurement = MakeMeasurement(meta.TopologyProfilingData[i], (double)data.TopologyProfilingData[i]);
                    measurements.Add(measurement);
                }
            }

            {
                // Convert values from array in "MeasurementValidationFlags" field to measurements
                ArrayMapping arrayMapping = (ArrayMapping)fieldLookup["MeasurementValidationFlags"];
                int dataLength = data.MeasurementValidationFlags.Length;
                int metaLength = meta.MeasurementValidationFlags.Length;

                if (dataLength != metaLength)
                    throw new InvalidOperationException($"Values array length ({dataLength}) and MetaValues array length ({metaLength}) for field \"MeasurementValidationFlags\" must be the same.");

                for (int i = 0; i < dataLength; i++)
                {
                    IMeasurement measurement = MakeMeasurement(meta.MeasurementValidationFlags[i], (double)data.MeasurementValidationFlags[i]);
                    measurements.Add(measurement);
                }
            }

            {
                // Convert values from array in "VoltageMagnitudeEstimates" field to measurements
                ArrayMapping arrayMapping = (ArrayMapping)fieldLookup["VoltageMagnitudeEstimates"];
                int dataLength = data.VoltageMagnitudeEstimates.Length;
                int metaLength = meta.VoltageMagnitudeEstimates.Length;

                if (dataLength != metaLength)
                    throw new InvalidOperationException($"Values array length ({dataLength}) and MetaValues array length ({metaLength}) for field \"VoltageMagnitudeEstimates\" must be the same.");

                for (int i = 0; i < dataLength; i++)
                {
                    IMeasurement measurement = MakeMeasurement(meta.VoltageMagnitudeEstimates[i], (double)data.VoltageMagnitudeEstimates[i]);
                    measurements.Add(measurement);
                }
            }

            {
                // Convert values from array in "VoltageAngleEstimates" field to measurements
                ArrayMapping arrayMapping = (ArrayMapping)fieldLookup["VoltageAngleEstimates"];
                int dataLength = data.VoltageAngleEstimates.Length;
                int metaLength = meta.VoltageAngleEstimates.Length;

                if (dataLength != metaLength)
                    throw new InvalidOperationException($"Values array length ({dataLength}) and MetaValues array length ({metaLength}) for field \"VoltageAngleEstimates\" must be the same.");

                for (int i = 0; i < dataLength; i++)
                {
                    IMeasurement measurement = MakeMeasurement(meta.VoltageAngleEstimates[i], (double)data.VoltageAngleEstimates[i]);
                    measurements.Add(measurement);
                }
            }

            {
                // Convert values from array in "VoltageMagnitudeResiduals" field to measurements
                ArrayMapping arrayMapping = (ArrayMapping)fieldLookup["VoltageMagnitudeResiduals"];
                int dataLength = data.VoltageMagnitudeResiduals.Length;
                int metaLength = meta.VoltageMagnitudeResiduals.Length;

                if (dataLength != metaLength)
                    throw new InvalidOperationException($"Values array length ({dataLength}) and MetaValues array length ({metaLength}) for field \"VoltageMagnitudeResiduals\" must be the same.");

                for (int i = 0; i < dataLength; i++)
                {
                    IMeasurement measurement = MakeMeasurement(meta.VoltageMagnitudeResiduals[i], (double)data.VoltageMagnitudeResiduals[i]);
                    measurements.Add(measurement);
                }
            }

            {
                // Convert values from array in "VoltageAngleResiduals" field to measurements
                ArrayMapping arrayMapping = (ArrayMapping)fieldLookup["VoltageAngleResiduals"];
                int dataLength = data.VoltageAngleResiduals.Length;
                int metaLength = meta.VoltageAngleResiduals.Length;

                if (dataLength != metaLength)
                    throw new InvalidOperationException($"Values array length ({dataLength}) and MetaValues array length ({metaLength}) for field \"VoltageAngleResiduals\" must be the same.");

                for (int i = 0; i < dataLength; i++)
                {
                    IMeasurement measurement = MakeMeasurement(meta.VoltageAngleResiduals[i], (double)data.VoltageAngleResiduals[i]);
                    measurements.Add(measurement);
                }
            }

            {
                // Convert values from array in "CurrentFlowMagnitudeEstimates" field to measurements
                ArrayMapping arrayMapping = (ArrayMapping)fieldLookup["CurrentFlowMagnitudeEstimates"];
                int dataLength = data.CurrentFlowMagnitudeEstimates.Length;
                int metaLength = meta.CurrentFlowMagnitudeEstimates.Length;

                if (dataLength != metaLength)
                    throw new InvalidOperationException($"Values array length ({dataLength}) and MetaValues array length ({metaLength}) for field \"CurrentFlowMagnitudeEstimates\" must be the same.");

                for (int i = 0; i < dataLength; i++)
                {
                    IMeasurement measurement = MakeMeasurement(meta.CurrentFlowMagnitudeEstimates[i], (double)data.CurrentFlowMagnitudeEstimates[i]);
                    measurements.Add(measurement);
                }
            }

            {
                // Convert values from array in "CurrentFlowAngleEstimates" field to measurements
                ArrayMapping arrayMapping = (ArrayMapping)fieldLookup["CurrentFlowAngleEstimates"];
                int dataLength = data.CurrentFlowAngleEstimates.Length;
                int metaLength = meta.CurrentFlowAngleEstimates.Length;

                if (dataLength != metaLength)
                    throw new InvalidOperationException($"Values array length ({dataLength}) and MetaValues array length ({metaLength}) for field \"CurrentFlowAngleEstimates\" must be the same.");

                for (int i = 0; i < dataLength; i++)
                {
                    IMeasurement measurement = MakeMeasurement(meta.CurrentFlowAngleEstimates[i], (double)data.CurrentFlowAngleEstimates[i]);
                    measurements.Add(measurement);
                }
            }

            {
                // Convert values from array in "CurrentFlowMagnitudeResiduals" field to measurements
                ArrayMapping arrayMapping = (ArrayMapping)fieldLookup["CurrentFlowMagnitudeResiduals"];
                int dataLength = data.CurrentFlowMagnitudeResiduals.Length;
                int metaLength = meta.CurrentFlowMagnitudeResiduals.Length;

                if (dataLength != metaLength)
                    throw new InvalidOperationException($"Values array length ({dataLength}) and MetaValues array length ({metaLength}) for field \"CurrentFlowMagnitudeResiduals\" must be the same.");

                for (int i = 0; i < dataLength; i++)
                {
                    IMeasurement measurement = MakeMeasurement(meta.CurrentFlowMagnitudeResiduals[i], (double)data.CurrentFlowMagnitudeResiduals[i]);
                    measurements.Add(measurement);
                }
            }

            {
                // Convert values from array in "CurrentFlowAngleResiduals" field to measurements
                ArrayMapping arrayMapping = (ArrayMapping)fieldLookup["CurrentFlowAngleResiduals"];
                int dataLength = data.CurrentFlowAngleResiduals.Length;
                int metaLength = meta.CurrentFlowAngleResiduals.Length;

                if (dataLength != metaLength)
                    throw new InvalidOperationException($"Values array length ({dataLength}) and MetaValues array length ({metaLength}) for field \"CurrentFlowAngleResiduals\" must be the same.");

                for (int i = 0; i < dataLength; i++)
                {
                    IMeasurement measurement = MakeMeasurement(meta.CurrentFlowAngleResiduals[i], (double)data.CurrentFlowAngleResiduals[i]);
                    measurements.Add(measurement);
                }
            }

            {
                // Convert values from openLSE.Model.LSE.PerformanceMetrics UDT for "PerformanceMetrics" field to measurements
                FieldMapping fieldMapping = fieldLookup["PerformanceMetrics"];
                TypeMapping nestedMapping = GetTypeMapping(fieldMapping);
                CollectFromLSEPerformanceMetrics(measurements, nestedMapping, data.PerformanceMetrics, meta.PerformanceMetrics);
            }
        }

        private void CollectFromLSEPerformanceMetrics(List<IMeasurement> measurements, TypeMapping typeMapping, openLSE.Model.LSE.PerformanceMetrics data, openLSE.Model.LSE._PerformanceMetricsMeta meta)
        {
            Dictionary<string, FieldMapping> fieldLookup = typeMapping.FieldMappings.ToDictionary(mapping => mapping.Field.Identifier);

            {
                // Convert value from "ActiveVoltagesCount" field to measurement
                FieldMapping fieldMapping = fieldLookup["ActiveVoltagesCount"];
                IMeasurement measurement = MakeMeasurement(meta.ActiveVoltagesCount, (double)data.ActiveVoltagesCount);
                measurements.Add(measurement);
            }

            {
                // Convert value from "ActiveCurrentFlowsCount" field to measurement
                FieldMapping fieldMapping = fieldLookup["ActiveCurrentFlowsCount"];
                IMeasurement measurement = MakeMeasurement(meta.ActiveCurrentFlowsCount, (double)data.ActiveCurrentFlowsCount);
                measurements.Add(measurement);
            }

            {
                // Convert value from "ActiveCurrentInjectionsCount" field to measurement
                FieldMapping fieldMapping = fieldLookup["ActiveCurrentInjectionsCount"];
                IMeasurement measurement = MakeMeasurement(meta.ActiveCurrentInjectionsCount, (double)data.ActiveCurrentInjectionsCount);
                measurements.Add(measurement);
            }

            {
                // Convert value from "RefreshTime" field to measurement
                FieldMapping fieldMapping = fieldLookup["RefreshTime"];
                IMeasurement measurement = MakeMeasurement(meta.RefreshTime, (double)data.RefreshTime);
                measurements.Add(measurement);
            }

            {
                // Convert value from "ParsingTime" field to measurement
                FieldMapping fieldMapping = fieldLookup["ParsingTime"];
                IMeasurement measurement = MakeMeasurement(meta.ParsingTime, (double)data.ParsingTime);
                measurements.Add(measurement);
            }

            {
                // Convert value from "MeasurementMappingTime" field to measurement
                FieldMapping fieldMapping = fieldLookup["MeasurementMappingTime"];
                IMeasurement measurement = MakeMeasurement(meta.MeasurementMappingTime, (double)data.MeasurementMappingTime);
                measurements.Add(measurement);
            }

            {
                // Convert value from "ActiveCurrentDeterminationTime" field to measurement
                FieldMapping fieldMapping = fieldLookup["ActiveCurrentDeterminationTime"];
                IMeasurement measurement = MakeMeasurement(meta.ActiveCurrentDeterminationTime, (double)data.ActiveCurrentDeterminationTime);
                measurements.Add(measurement);
            }

            {
                // Convert value from "ObservabilityAnalysisTime" field to measurement
                FieldMapping fieldMapping = fieldLookup["ObservabilityAnalysisTime"];
                IMeasurement measurement = MakeMeasurement(meta.ObservabilityAnalysisTime, (double)data.ObservabilityAnalysisTime);
                measurements.Add(measurement);
            }

            {
                // Convert value from "StateComputationTime" field to measurement
                FieldMapping fieldMapping = fieldLookup["StateComputationTime"];
                IMeasurement measurement = MakeMeasurement(meta.StateComputationTime, (double)data.StateComputationTime);
                measurements.Add(measurement);
            }

            {
                // Convert value from "ObservedBusCount" field to measurement
                FieldMapping fieldMapping = fieldLookup["ObservedBusCount"];
                IMeasurement measurement = MakeMeasurement(meta.ObservedBusCount, (double)data.ObservedBusCount);
                measurements.Add(measurement);
            }

            {
                // Convert value from "OutputPreparationTime" field to measurement
                FieldMapping fieldMapping = fieldLookup["OutputPreparationTime"];
                IMeasurement measurement = MakeMeasurement(meta.OutputPreparationTime, (double)data.OutputPreparationTime);
                measurements.Add(measurement);
            }

            {
                // Convert value from "TotalTimeInMilliseconds" field to measurement
                FieldMapping fieldMapping = fieldLookup["TotalTimeInMilliseconds"];
                IMeasurement measurement = MakeMeasurement(meta.TotalTimeInMilliseconds, (double)data.TotalTimeInMilliseconds);
                measurements.Add(measurement);
            }

            {
                // Convert value from "TotalTimeInTicks" field to measurement
                FieldMapping fieldMapping = fieldLookup["TotalTimeInTicks"];
                IMeasurement measurement = MakeMeasurement(meta.TotalTimeInTicks, (double)data.TotalTimeInTicks);
                measurements.Add(measurement);
            }
        }

        #endregion
    }
}
