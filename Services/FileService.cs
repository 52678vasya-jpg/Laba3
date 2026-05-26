using InflationAnalyzer.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace InflationAnalyzer.Services
{
    // Сервис загрузки JSON файла
    public class FileService
    {
        // Метод загрузки данных
        public List<InflationData> LoadData(
            string path)
        {
            // Чтение JSON
            string json =
                File.ReadAllText(path);

            // Преобразование JSON в список
            List<InflationData>? data =
                JsonSerializer.Deserialize
                <List<InflationData>>(json);

            // Возврат данных
            return data ??
                new List<InflationData>();
        }
    }
}