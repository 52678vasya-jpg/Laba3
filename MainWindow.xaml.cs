using System.Windows;

namespace InflationAnalyzer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // 10 вариант
        private void Variant1Button_Click(
            object sender,
            RoutedEventArgs e)
        {
            InflationWindow window =
                new InflationWindow();

            window.Show();
        }

        // 5 вариант(товарища)
        private void Variant2Button_Click(
            object sender,
            RoutedEventArgs e)
        {
            Variant5Window window =
                new Variant5Window();

            window.Show();
        }

        // 7 вариант(товарища)
        private void Variant3Button_Click(
            object sender,
            RoutedEventArgs e)
        {
            Variant7Window window =
                new Variant7Window();

            window.Show();
        }
    }
}