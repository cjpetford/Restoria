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
        await Navigation.PushAsync(new RegisterContinued());
    }
}