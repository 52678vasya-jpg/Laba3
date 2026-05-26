using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using OxyPlot.Wpf;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lab3_VCS
{
    public class ChartManager : INotifyPropertyChanged
    {
        private PlotModel _plotModel;

        public PlotModel PlotModel
        {
            get => _plotModel;
            set
            {
                _plotModel = value;
                OnPropertyChanged();
            }
        }

        public ChartManager()
        {
            PlotModel = new PlotModel { Title = "Динамика браков и разводов" };
            PlotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Год" });
            PlotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Количество" });
        }

        public void DrawBaseData(List<DemographicData> data)
        {
            PlotModel.Series.Clear();

            var marriageSeries = new LineSeries { Title = "Браки", Color = OxyColors.Blue };
            var divorceSeries = new LineSeries { Title = "Разводы", Color = OxyColors.Red };

            foreach (var item in data)
            {
                marriageSeries.Points.Add(new DataPoint(item.Year, item.Marriages));
                divorceSeries.Points.Add(new DataPoint(item.Year, item.Divorces));
            }

            PlotModel.Series.Add(marriageSeries);
            PlotModel.Series.Add(divorceSeries);
            PlotModel.InvalidatePlot(true);
        }

        public void AddForecast(List<double> forecastData, int startYear)
        {
            var forecastSeries = new LineSeries
            {
                Title = "Прогноз (Браки)",
                Color = OxyColors.Green,
                LineStyle = LineStyle.Dash
            };

            for (int i = 0; i < forecastData.Count; i++)
            {
                forecastSeries.Points.Add(new DataPoint(startYear + i, forecastData[i]));
            }

            PlotModel.Series.Add(forecastSeries);
            PlotModel.InvalidatePlot(true);
        }

        public void ExportToPng(string filePath)
        {
            using (var stream = File.Create(filePath))
            {
                var exporter = new PngExporter { Width = 800, Height = 600 };
                exporter.Export(PlotModel, stream);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}