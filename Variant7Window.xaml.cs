using System.Windows;
using Microsoft.Win32;

<<<<<<< Updated upstream
namespace Lab3_VCS
=======
namespace InflationAnalyzer
>>>>>>> Stashed changes
{
    public partial class Variant7Window : Window
    {
        private readonly IDataProcessor _dataProcessor;
        private readonly IForecastingService _forecaster;
        private readonly ChartManager _chartManager;
        private List<DemographicData> _currentData;

        public Variant7Window()
        {
            InitializeComponent();
            _dataProcessor = new JsonDataProcessor();
            _forecaster = new MovingAverageForecaster();
            _chartManager = new ChartManager();
            DataContext = _chartManager;
        }

        private void LoadData_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog { Filter = "JSON files (*.json)|*.json" };
            if (openFileDialog.ShowDialog() == true)
            {
                _currentData = _dataProcessor.LoadData(openFileDialog.FileName);
                DataGridStats.ItemsSource = _currentData;

                var analysis = _dataProcessor.CalculateMostFrequentAges(_currentData);
                TxtAnalysis.Text = $"Аналитика за 15 лет:\nЧастый возраст брака (М): {analysis.MenMarriage}\nЧастый возраст развода (М): {analysis.MenDivorce}\nЧастый возраст брака (Ж): {analysis.WomenMarriage}\nЧастый возраст развода (Ж): {analysis.WomenDivorce}";

                _chartManager.DrawBaseData(_currentData);
            }
        }

        private void Predict_Click(object sender, RoutedEventArgs e)
        {
            if (_currentData == null || _currentData.Count == 0) return;

            if (int.TryParse(TxtPeriod.Text, out int n) && int.TryParse(TxtHorizon.Text, out int horizon))
            {
                var marriages = _currentData.Select(d => (double)d.Marriages).ToList();
                var forecast = _forecaster.CalculateForecast(marriages, n, horizon);

                int startYear = _currentData.Last().Year + 1;
                _chartManager.AddForecast(forecast, startYear);
            }
            else
            {
                MessageBox.Show("Введите корректные числовые значения для n и горизонта прогноза.");
            }
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog { Filter = "PNG Image (*.png)|*.png" };
            if (saveFileDialog.ShowDialog() == true)
            {
                _chartManager.ExportToPng(saveFileDialog.FileName);
                MessageBox.Show("График успешно экспортирован!");
            }
        }
    }
}