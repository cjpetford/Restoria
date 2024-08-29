using Microsoft.Maui.Controls;
using restoria.MVVM.ViewModels;
using restoria.MVVM.Views;

namespace restoria
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel(); // Set the ViewModel as the BindingContext
        }
    }
}
