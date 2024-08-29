using restoria.MVVM.ViewModels;

namespace restoria;

public partial class OnboardingPage : ContentPage
{
	public OnboardingPage()
	{
		InitializeComponent();
		BindingContext = new OnboardingPageViewModel();
	}
}
