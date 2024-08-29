namespace restoria.MVVM.Views;

public partial class RegisterContinued : ContentPage
{
    public RegisterContinued()
    {
        InitializeComponent();
    }

    private async void OnExistingUserTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }
}