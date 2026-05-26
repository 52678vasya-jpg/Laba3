<<<<<<< Updated upstream
﻿using System;
=======
﻿using Microsoft.Win32;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.Wpf;
using System;
>>>>>>> Stashed changes
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
<<<<<<< Updated upstream
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
=======

namespace InflationAnalyzer
{
    public partial class Variant5Window : Window
    {
        // Исторические данные
        private List<PopulationRecord> _historicalData =
            new List<PopulationRecord>();

        // Анализатор
        private readonly IAnalyzer _analyzer;

        // Модель графика
        private PlotModel _plotModel =
            new PlotModel();
>>>>>>> Stashed changes

        public Variant5Window()
        {
            InitializeComponent();
<<<<<<< Updated upstream
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

=======

            _analyzer =
                new PopulationAnalyzer();

            InitializeChart();
        }

        // Инициализация графика
        private void InitializeChart()
        {
            _plotModel =
                new PlotModel
                {
                    Title =
                        "Численность населения России"
                };

            _plotModel.Axes.Add(
                new LinearAxis
                {
                    Position =
                        AxisPosition.Bottom,

                    Title = "Год"
                });

            _plotModel.Axes.Add(
                new LinearAxis
                {
                    Position =
                        AxisPosition.Left,

                    Title =
                        "Население (млн)"
                });

            PlotPopulation.Model =
                _plotModel;
        }

        // Загрузка JSON через выбор файла
        private void LoadData_Click(
            object sender,
            RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog =
                    new OpenFileDialog();

                openFileDialog.Filter =
                    "JSON files (*.json)|*.json";

                if (openFileDialog.ShowDialog()
                    == true)
                {
                    string json =
                        File.ReadAllText(
                            openFileDialog.FileName);

                    _historicalData =
                        JsonSerializer.Deserialize
                        <List<PopulationRecord>>(json)
                        ?? new List<PopulationRecord>();

                    // Вывод таблицы
                    DataGridPopulation.ItemsSource =
                        _historicalData;

                    // Аналитика
                    var extremes =
                        _analyzer.CalculateExtremes(
                            _historicalData);

                    TxtStats.Text =
                        $"Макс. прирост: " +
                        $"{extremes.maxGrowth:F2}%\n" +

                        $"Макс. убыль: " +
                        $"{extremes.maxDecline:F2}%";

                    DrawHistoricalData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ошибка загрузки: " +
                    $"{ex.Message}");
            }
        }

        // Отрисовка графика
>>>>>>> Stashed changes
        private void DrawHistoricalData()
        {
            _plotModel.Series.Clear();

<<<<<<< Updated upstream
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
=======
            LineSeries lineSeries =
                new LineSeries
                {
                    Title =
                        "Исторические данные",

                    Color =
                        OxyColors.Blue,

                    MarkerType =
                        MarkerType.Circle
                };

            foreach (var record
                in _historicalData)
            {
                lineSeries.Points.Add(
                    new DataPoint(
                        record.Year,
                        record.Population));
            }

            _plotModel.Series.Add(
                lineSeries);

            PlotPopulation
                .InvalidatePlot(true);
        }

        // Построение прогноза
        private void Predict_Click(
            object sender,
            RoutedEventArgs e)
        {
            if (_historicalData == null ||
                !_historicalData.Any())
            {
                return;
            }

            int n =
                int.Parse(TxtN.Text);

            int years =
                int.Parse(TxtYears.Text);

            var predictions =
                _analyzer
                .PredictMovingAverage(
                    _historicalData,
                    n,
                    years);

            LineSeries forecastSeries =
                new LineSeries
                {
                    Title =
                        "Прогноз",

                    Color =
                        OxyColors.Red,

                    LineStyle =
                        LineStyle.Dash,

                    MarkerType =
                        MarkerType.Square
                };

            // Последняя историческая точка
            var lastHistory =
                _historicalData.Last();

            forecastSeries.Points.Add(
                new DataPoint(
                    lastHistory.Year,
                    lastHistory.Population));

            // Добавление прогноза
            foreach (var record
                in predictions)
            {
                forecastSeries.Points.Add(
                    new DataPoint(
                        record.Year,
                        record.Population));
            }

            // Удаляем старый прогноз
            if (_plotModel.Series.Count > 1)
            {
                _plotModel.Series.RemoveAt(1);
            }

            // Добавляем новый
            _plotModel.Series.Add(
                forecastSeries);

            PlotPopulation
                .InvalidatePlot(true);
        }

        // Экспорт PNG
        private void Export_Click(
            object sender,
            RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog =
                    new SaveFileDialog();

                saveFileDialog.Filter =
                    "PNG Image (*.png)|*.png";

                if (saveFileDialog.ShowDialog()
                    == true)
                {
                    PngExporter exporter =
                        new PngExporter
                        {
                            Width = 800,
                            Height = 600
                        };

                    exporter.ExportToFile(
                        _plotModel,
                        saveFileDialog.FileName);

                    MessageBox.Show(
                        "График успешно экспортирован!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
>>>>>>> Stashed changes
        }
    }
}