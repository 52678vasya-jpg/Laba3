using System.Windows;

namespace InflationAnalyzer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Вариант 1
        private void Variant1Button_Click(
            object sender,
            RoutedEventArgs e)
        {
            InflationWindow window =
                new InflationWindow();

            window.Show();
        }

        // Вариант 2
        private void Variant2Button_Click(
            object sender,
            RoutedEventArgs e)
        {
            Variant2Window window =
                new Variant2Window();

            window.Show();
        }

        // Вариант 3
        private void Variant3Button_Click(
            object sender,
            RoutedEventArgs e)
        {
            Variant3Window window =
                new Variant3Window();

            window.Show();
        }
    }
}