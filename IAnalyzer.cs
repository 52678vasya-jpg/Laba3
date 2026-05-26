using System.Collections.Generic;

namespace InflationAnalyzer
{
    public interface IAnalyzer
    {
        (double maxGrowth,
         double maxDecline)
        CalculateExtremes(
            List<PopulationRecord> data);

        List<PopulationRecord>
        PredictMovingAverage(
            List<PopulationRecord> data,
            int n,
            int years);
    }
}