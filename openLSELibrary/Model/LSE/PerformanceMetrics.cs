// COMPILER GENERATED CODE
// THIS WILL BE OVERWRITTEN AT EACH GENERATION
// EDIT AT YOUR OWN RISK

using System.Runtime.CompilerServices;

namespace openLSE.Model.LSE
{
    [CompilerGenerated]
    public partial class PerformanceMetrics
    {
        public int ActiveVoltagesCount { get; set; }
        public int ActiveCurrentFlowsCount { get; set; }
        public int ActiveCurrentInjectionsCount { get; set; }
        public double RefreshTime { get; set; }
        public double ParsingTime { get; set; }
        public double MeasurementMappingTime { get; set; }
        public double ActiveCurrentDeterminationTime { get; set; }
        public double ObservabilityAnalysisTime { get; set; }
        public double StateComputationTime { get; set; }
        public int ObservedBusCount { get; set; }
        public double OutputPreparationTime { get; set; }
        public double TotalTimeInMilliseconds { get; set; }
        public long TotalTimeInTicks { get; set; }
    }
}