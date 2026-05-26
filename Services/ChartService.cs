using InflationAnalyzer.Models;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System.Collections.Generic;

namespace InflationAnalyzer.Services
{
    // Сервис построения графиков
    public class ChartService
    {
        // Создание графика
        public PlotModel CreateChart(
            List<InflationData> data)
        {
            // Модель графика
            PlotModel model =
                new PlotModel
                {
                    Title = "Inflation Forecast"
                };

            // Ось годов
            model.Axes.Add(
                new LinearAxis
                {
                    Position = AxisPosition.Bottom,
                    Title = "Year"
                });

            // Ось инфляции
            model.Axes.Add(
                new LinearAxis
                {
                    Position = AxisPosition.Left,
                    Title = "Inflation %"
                });

            // Линия графика
            LineSeries series =
                new LineSeries
                {
                    Title = "Inflation"
                };

            // Добавление точек
            foreach (InflationData item in data)
            {
                series.Points.Add(
                    new DataPoint(
                        item.Year,
                        item.Inflation));
            }

            // Добавление линии
            model.Series.Add(series);

            return model;
        }
    }
}