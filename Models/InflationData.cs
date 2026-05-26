namespace InflationAnalyzer.Models
{
    // Модель данных инфляции
    public class InflationData
    {
        // Год
        public int Year { get; set; }

        // Процент инфляции
        public double Inflation { get; set; }

        // Цена квартиры
        public double ApartmentPrice { get; set; }
    }
}