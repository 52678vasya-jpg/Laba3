using InflationAnalyzer.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace InflationAnalyzer.Helpers
{
    public static class JsonHelper
    {
        // Загрузка JSON файла
        public static List<InflationData> LoadJson(
            string path)
        {
            string json =
                File.ReadAllText(path);

            return JsonSerializer.Deserialize
                <List<InflationData>>(json);
        }
    }
}