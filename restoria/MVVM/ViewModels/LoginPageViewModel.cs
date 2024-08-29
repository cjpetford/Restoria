using System;
using System.Windows.Input;
using restoria.MVVM.Views;
using restoria.MVVM.ViewModels.Base;
using restoria.MVVM.ViewModels;

namespace restoria.MVVM.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
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

