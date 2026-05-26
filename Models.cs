using System.Collections.Generic;

namespace Lab3_VCS
{
    // Модель данных за один год
    public class DemographicData
    {
        public int Year { get; set; }
        public int Marriages { get; set; }
        public int Divorces { get; set; }
        public int PeakMarriageAgeMen { get; set; }
        public int PeakDivorceAgeMen { get; set; }
        public int PeakMarriageAgeWomen { get; set; }
        public int PeakDivorceAgeWomen { get; set; }
    }

    // Модель для результатов аналитики
    public class AgeAnalysisResult
    {
        public int MenMarriage { get; set; }
        public int MenDivorce { get; set; }
        public int WomenMarriage { get; set; }
        public int WomenDivorce { get; set; }
    }
}