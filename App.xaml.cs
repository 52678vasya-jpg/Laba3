using System.Windows;

namespace UnifiedApp
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Здесь мы создаем общее окно-меню (Dashboard)
            // которое должно быть у вас в проекте
            var mainMenu = new MainDashboardWindow(); 
            mainMenu.Show();
        }
    }
}