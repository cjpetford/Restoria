using restoria.MVVM.ViewModels;
using restoria.MVVM.Views;
using restoria.MVVM.Models;

namespace restoria;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
        BindingContext = new LoginPageViewModel(new DatabaseService());
    }

    private async void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        var user = new User
        {
            Email = emailEntry.Text,
            Password = passwordEntry.Text,
            Role = "User" // or "Admin" based on your logic
        };

        var databaseService = new DatabaseService();
        await databaseService.AddUserAsync(user);

        // Navigate or show success message
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
