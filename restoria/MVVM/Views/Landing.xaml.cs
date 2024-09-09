namespace BookingAppRestoria.MVVM.Views;

public partial class Landing : ContentPage
{
	public Landing()
	{
		InitializeComponent();

        NavigateToLoginPage();
    }

    private async void NavigateToLoginPage()
    {
        // Wait for 10 seconds --> Login Page
        await Task.Delay(5000);

        // Navigate to the Login Page
        await Navigation.PushAsync(new Login());
    }
}
