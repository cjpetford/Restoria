using BookingAppRestoria.MVVM.Views;

namespace BookingAppRestoria.MVVM.Views;

public partial class PrivacyPolicy : ContentPage
{
	public PrivacyPolicy()
	{
		InitializeComponent();
    }

	// =====================================================
	// ========= BUTTON TO GO BACK TO SIGN IN PAGE =========
    private async void PP_ContinueButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}