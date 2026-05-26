using System.Collections.Generic;

<<<<<<< Updated upstream
namespace Lab3_VCS
=======
namespace InflationAnalyzer
>>>>>>> Stashed changes
{
    public interface IDataProcessor
    {
        List<DemographicData> LoadData(string filePath);
        AgeAnalysisResult CalculateMostFrequentAges(List<DemographicData> data);
    }

    public interface IForecastingService
    {
        List<double> CalculateForecast(List<double> historicalData, int period, int horizon);
    }
}