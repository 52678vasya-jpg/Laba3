using InflationAnalyzer.Models;
using System.Collections.Generic;
using System.Linq;

namespace InflationAnalyzer.Services
{
    // Сервис прогнозирования инфляции
    public class ForecastService
    {
        // Метод создания прогноза
        public List<InflationData> CreateForecast(
            List<InflationData> data,
            int targetYear)
        {
            // Копия исходных данных
            List<InflationData> result =
                new List<InflationData>(data);

            // Последний год
            int lastYear =
                data.Last().Year;

            // Последняя цена квартиры
            double apartmentPrice =
                data.Last().ApartmentPrice;

            // Пока не дошли до нужного года
            while (lastYear < targetYear)
            {
                // Берем последние 3 значения инфляции
                List<double> lastValues =
                    result
                    .Skip(result.Count - 3)
                    .Select(x => x.Inflation)
                    .ToList();

                // Скользящая средняя
                double average =
                    lastValues.Average();

                // Новая цена квартиры
                apartmentPrice +=
                    apartmentPrice * average / 100;

                // Следующий год
                lastYear++;

                // Добавляем прогноз
                result.Add(new InflationData
                {
                    Year = lastYear,
                    Inflation = average,
                    ApartmentPrice = apartmentPrice
                });
            }

            return result;
        }
    }
}