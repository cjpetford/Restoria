using restoria.MVVM.ViewModels;
using restoria.MVVM.Views;

namespace restoria;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
		BindingContext = new LoginPageViewModel();
    }

    private async void OnRegisterTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Register());
    }

    private async void ForgotPassword(object sender, EventArgs e)
    {
        await DisplayAlert("Forgot Password", "A link to reset your password has been sent to your email.", "OK");
    }
}
