using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

<<<<<<< Updated upstream
namespace Lab3_VCS
=======
namespace InflationAnalyzer
>>>>>>> Stashed changes
{
    public class JsonDataProcessor : IDataProcessor
    {
        public List<DemographicData> LoadData(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<DemographicData>>(jsonString) ?? new List<DemographicData>();
        }

        public AgeAnalysisResult CalculateMostFrequentAges(List<DemographicData> data)
        {
            return new AgeAnalysisResult
            {
                MenMarriage = GetMode(data.Select(d => d.PeakMarriageAgeMen)),
                MenDivorce = GetMode(data.Select(d => d.PeakDivorceAgeMen)),
                WomenMarriage = GetMode(data.Select(d => d.PeakMarriageAgeWomen)),
                WomenDivorce = GetMode(data.Select(d => d.PeakDivorceAgeWomen))
            };
        }

        // Вспомогательный метод для поиска наиболее часто встречающегося значения (моды)
        private int GetMode(IEnumerable<int> numbers)
        {
            return numbers.GroupBy(v => v)
                          .OrderByDescending(g => g.Count())
                          .First()
                          .Key;
        }
    }
}