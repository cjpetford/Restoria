using restoria.MVVM.ViewModels;

namespace restoria.MVVM.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
        BindingContext = new LoginPageViewModel();
    }
}