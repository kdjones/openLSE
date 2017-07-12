// COMPILER GENERATED CODE
// THIS WILL BE OVERWRITTEN AT EACH GENERATION
// EDIT AT YOUR OWN RISK

using System.Runtime.CompilerServices;

namespace openLSE.Model.LSE
{
    [CompilerGenerated]
    public partial class EstimatorOutput
    {
        public double[] CircuitBreakerStatuses { get; set; }
        public double[] TopologyProfilingData { get; set; }
        public double[] MeasurementValidationFlags { get; set; }
        public double[] VoltageMagnitudeEstimates { get; set; }
        public double[] VoltageAngleEstimates { get; set; }
        public double[] VoltageMagnitudeResiduals { get; set; }
        public double[] VoltageAngleResiduals { get; set; }
        public double[] CurrentFlowMagnitudeEstimates { get; set; }
        public double[] CurrentFlowAngleEstimates { get; set; }
        public double[] CurrentFlowMagnitudeResiduals { get; set; }
        public double[] CurrentFlowAngleResiduals { get; set; }
        public openLSE.Model.LSE.PerformanceMetrics PerformanceMetrics { get; set; }
    }
}