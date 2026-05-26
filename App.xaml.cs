<<<<<<< Updated upstream
using System.Windows;

namespace UnifiedApp
=======
using InflationAnalyzer;
using System.Windows;

namespace InflationAnalyzer
>>>>>>> Stashed changes
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Здесь мы создаем общее окно-меню (Dashboard)
            // которое должно быть у вас в проекте
<<<<<<< Updated upstream
            var mainMenu = new MainDashboardWindow(); 
=======
            var mainMenu = new MainWindow();
>>>>>>> Stashed changes
            mainMenu.Show();
        }
    }
}