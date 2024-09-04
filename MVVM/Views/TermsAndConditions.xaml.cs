using BookingAppRestoria.MVVM.Views;

namespace BookingAppRestoria.MVVM.Views;

public partial class TermsAndConditions : ContentPage
{
	public TermsAndConditions()
	{
		InitializeComponent();
	}

    private async void TC_ContinueButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Registration()); 
    }
}