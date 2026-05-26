using System.Collections.Generic;
using System.Linq;

<<<<<<< Updated upstream
namespace Lab3_VCS
=======
namespace InflationAnalyzer
>>>>>>> Stashed changes
{
    public class MovingAverageForecaster : IForecastingService
    {
        public List<double> CalculateForecast(List<double> historicalData, int period, int horizon)
        {
            var resultForecast = new List<double>();
            var currentData = new List<double>(historicalData);

            for (int i = 0; i < horizon; i++)
            {
                // Берем последние 'period' элементов для расчета среднего
                var recentData = currentData.Skip(currentData.Count - period).Take(period);
                double nextValue = recentData.Average();

                resultForecast.Add(nextValue);
                currentData.Add(nextValue); // Добавляем прогнозное значение для расчета следующих
            }

            return resultForecast;
        }
    }
}