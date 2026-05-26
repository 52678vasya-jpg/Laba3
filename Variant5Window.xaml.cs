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

                
