using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace RestoriaApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Set the main page to MainTabbedPage
            MainPage = new DashboardPage();
        }
    }
}