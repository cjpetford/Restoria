using static DatabaseService;
using restoria.MVVM.Models;
using restoria.MVVM.Views;

namespace restoria.MVVM.Views;

public partial class Register : ContentPage
{
    public Register()
    {
        InitializeComponent();
    }

    private async void OnExistingUserTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }

    private async void ProceedSignUp(object sender, EventArgs e)
    {
        var user = new User
        {
            FirstName = firstNameEntry.Text,
            LastName = lastNameEntry.Text
        };

        // Pass user data to RegisterContinued
        await Navigation.PushAsync(new RegisterContinued(user));
    }

}