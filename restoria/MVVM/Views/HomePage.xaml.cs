using Microsoft.Maui.Controls;
using restoria.MVVM.ViewModels;
using restoria.MVVM.Views;

namespace restoria.MVVM.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
		BindingContext = new HomePageViewModel();
    }
}
