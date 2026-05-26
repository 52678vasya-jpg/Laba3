using System;
using System.Collections.Generic;
using System.Linq;

namespace PopulationApp
{
    public interface IAnalyzer
    {
        (double maxGrowth, double maxDecline) CalculateExtremes(List<PopulationRecord> data);
        List<PopulationRecord> PredictMovingAverage(List<PopulationRecord> historicalData, int n, int yearsToPredict);
    }

    public class PopulationAnalyzer : IAnalyzer
    {
        public (double maxGrowth, double maxDecline) CalculateExtremes(List<PopulationRecord> data)
        {
            double maxGrowth = 0;
            double maxDecline = 0;

            for (int i = 1; i < data.Count; i++)
            {
                double percentChange = ((data[i].Population - data[i - 1].Population) / data[i - 1].Population) * 100;

                if (percentChange > maxGrowth) maxGrowth = percentChange;
                if (percentChange < maxDecline) maxDecline = percentChange;
            }

            return (maxGrowth, maxDecline);
        }

        // Прогнозирование экстраполяцией по скользящей средней
        public List<PopulationRecord> PredictMovingAverage(List<PopulationRecord> historicalData, int n, int yearsToPredict)
        {
            var predictions = new List<PopulationRecord>();
            
            var workingData = historicalData.Select(d => d.Population).ToList();

            int lastYear = historicalData.Last().Year;

            for (int i = 1; i <= yearsToPredict; i++)
            {
                // Берем последние n элементов
                var lastNValues = workingData.Skip(workingData.Count - n).Take(n);
                double average = lastNValues.Average();

                predictions.Add(new PopulationRecord { Year = lastYear + i, Population = average });
                workingData.Add(average); // Впитываем новую информацию [cite: 54]
            }

            return predictions;
        }
    }
}