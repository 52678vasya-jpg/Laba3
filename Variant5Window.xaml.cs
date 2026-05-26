using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Wpf;

namespace PopulationApp
{
    public partial class Variant5Window : Window
    {
        private List<PopulationRecord> _historicalData;
        private readonly IAnalyzer _analyzer;
        private PlotModel _plotModel;

        public Variant5Window()
        {
            InitializeComponent();
            _analyzer = new PopulationAnalyzer();
            InitializeChart();
        }

        private void InitializeChart()
        {
            _plotModel = new PlotModel { Title = "Численность населения России" };
            _plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis { Position = OxyPlot.Axes.AxisPosition.Bottom, Title = "Год" });
            _plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis { Position = OxyPlot.Axes.AxisPosition.Left, Title = "Население (млн)" });
            PlotPopulation.Model = _plotModel;
        }

        private void LoadData_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string json = File.ReadAllText("population.json");
                _historicalData = JsonSerializer.Deserialize<List<PopulationRecord>>(json);

                DataGridPopulation.ItemsSource = _historicalData; // Вывод в таблицу 

                
                var extremes = _analyzer.CalculateExtremes(_historicalData);
                TxtStats.Text = $"Макс. прирост: {extremes.maxGrowth:F2}%\nМакс. убыль: {extremes.maxDecline:F2}%";

                DrawHistoricalData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}");
            }
        }

        private void DrawHistoricalData()
        {
            _plotModel.Series.Clear();

            var lineSeries = new LineSeries
            {
                Title = "Исторические данные",
                Color = OxyColors.Blue,
                MarkerType = MarkerType.Circle
            };

            foreach (var record in _historicalData)
            {
                lineSeries.Points.Add(new DataPoint(record.Year, record.Population));
            }

            _plotModel.Series.Add(lineSeries);
            PlotPopulation.InvalidatePlot(true);
        }

        private void Predict_Click(object sender, RoutedEventArgs e)
        {
            if (_historicalData == null || !_historicalData.Any()) return;

            int n = int.Parse(TxtN.Text); // Ввод 'n' пользователем 
            int years = int.Parse(TxtYears.Text); // Количество лет для прогноза 

            var predictions = _analyzer.PredictMovingAverage(_historicalData, n, years);

            
            var forecastSeries = new LineSeries
            {
                Title = "Прогноз (Скользящая средняя)",
                Color = OxyColors.Red,
                LineStyle = LineStyle.Dash,
                MarkerType = MarkerType.Square
            };

            // Добавляем последнюю историческую точку для слитности графика
            var lastHistory = _historicalData.Last();
            forecastSeries.Points.Add(new DataPoint(lastHistory.Year, lastHistory.Population));

            foreach (var record in predictions)
            {
                forecastSeries.Points.Add(new DataPoint(record.Year, record.Population));
            }

            // Удаляем старый прогноз, если он был, и добавляем новый
            if (_plotModel.Series.Count > 1) _plotModel.Series.RemoveAt(1);
            _plotModel.Series.Add(forecastSeries);
            PlotPopulation.InvalidatePlot(true);
        }

        
        private void Export_Click(object sender, RoutedEventArgs e)
        {
            var pngExporter = new PngExporter { Width = 800, Height = 600 };
            pngExporter.ExportToFile(_plotModel, "PopulationChart.png");
            MessageBox.Show("График успешно экспортирован в PopulationChart.png!");
        }
    }
}