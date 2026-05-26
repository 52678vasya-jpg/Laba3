using InflationAnalyzer.Models;
using InflationAnalyzer.Services;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace InflationAnalyzer
{
    public partial class InflationWindow : Window
    {
        // Основные данные
        private List<InflationData> inflationData =
            new List<InflationData>();

        // Сервис загрузки
        private readonly FileService fileService =
            new FileService();

        // Сервис прогнозирования
        private readonly ForecastService forecastService =
            new ForecastService();

        // Сервис графиков
        private readonly ChartService chartService =
            new ChartService();

        // Конструктор окна
        public InflationWindow()
        {
            InitializeComponent();
        }

        // Загрузка JSON файла
        private void LoadButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            // Окно выбора файла
            OpenFileDialog dialog =
                new OpenFileDialog();

            // Фильтр JSON
            dialog.Filter =
                "JSON files (*.json)|*.json";

            // Проверка выбора
            if (dialog.ShowDialog() != true)
            {
                return;
            }

            // Загрузка данных
            inflationData =
                fileService.LoadData(
                    dialog.FileName);

            // Вывод таблицы
            InflationGrid.ItemsSource =
                inflationData;

            // Построение графика
            PlotView.Model =
                chartService.CreateChart(
                    inflationData);

            MessageBox.Show(
                "JSON loaded successfully!");
        }

        // Прогнозирование
        private void ForecastButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            // Проверка данных
            if (inflationData.Count == 0)
            {
                MessageBox.Show(
                    "Load JSON first!");

                return;
            }

            // Проверка года
            if (!int.TryParse(
                YearTextBox.Text,
                out int targetYear))
            {
                MessageBox.Show(
                    "Enter valid year!");

                return;
            }

            // Проверка будущего года
            if (targetYear <=
                inflationData.Last().Year)
            {
                MessageBox.Show(
                    "Enter future year!");

                return;
            }

            // Создание прогноза
            List<InflationData> forecast =
                forecastService.CreateForecast(
                    inflationData,
                    targetYear);

            // Обновление таблицы
            InflationGrid.ItemsSource =
                forecast;

            // Обновление графика
            PlotView.Model =
                chartService.CreateChart(
                    forecast);

            // Последняя цена квартиры
            double finalPrice =
                forecast.Last()
                .ApartmentPrice;

            // Вывод результата
            MessageBox.Show(
                $"Apartment price in {targetYear}: " +
                $"{finalPrice:F0} RUB");
        }
    }
}