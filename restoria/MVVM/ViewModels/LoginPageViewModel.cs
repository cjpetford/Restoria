using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using restoria.MVVM.Views;

namespace restoria.MVVM.ViewModels
{
    public class LoginPageViewModel : ContentPage
    {
        public ICommand ICommandNavToHomePage { get; set; }

        public LoginPageViewModel()
        {
            ICommandNavToHomePage = new Command(() => NavigateToHomePage());
        }

        private static void NavigateToHomePage()
        {
            Application.Current?.MainPage?.Navigation.PushAsync(new HomePage());
        }
    }
}

