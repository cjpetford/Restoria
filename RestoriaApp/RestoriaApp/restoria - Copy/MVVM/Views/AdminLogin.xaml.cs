using BookingAppRestoria.Services;
using BookingAppRestoria.MVVM.Models;
using Microsoft.Maui.Controls;

namespace BookingAppRestoria.MVVM.Views;

public partial class AdminLogin : ContentPage
{
    private CaptchaGenerator captchaGenerator;
    private readonly DatabaseService _databaseService;

    public AdminLogin()
	{
		InitializeComponent();

        _databaseService = new DatabaseService();

        captchaGenerator = new CaptchaGenerator();
        GenerateNewCaptcha();
    }

    //=====================================================
    //================ REGENERATING CAPTCHA ===============
    private void GenerateNewCaptcha()
    {
        // Generate a Captcha of length = number in ()
        string captcha = captchaGenerator.GenerateCaptcha(8);
        captchaLabel.Text = captcha;
    }

    //================================================
    //================ LOADING CAPTCHA ===============
    private void OnRefreshCaptchaClicked(object sender, EventArgs e)
    {
        GenerateNewCaptcha(); // Refresh the Captcha
    }


    //===========================================================
    //================ CANCEL ADMIN LOGIN INCASE  ===============
    private async void Cancel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void AdminLogin_Clicked(object sender, EventArgs e)
    {
        string username = emailEntry.Text;
        string password = passwordEntry.Text;

        // Instantiate AdminLoginServices
        var adminLoginService = new AdminLoginService();

        // Validate login credentials
        if (adminLoginService.ValidateAdminLogin(username, password))
        {
            // Login successful
            await DisplayAlert("Success", "Login successful!", "OK");

            // Check if the user is an admin
            if (adminLoginService.IsAdmin)
            {
                // Navigate to the homepage or admin dashboard
                await Navigation.PushAsync(new AdminPage());
            }
            else
            {
                // Optionally handle cases where login is successful but user is not admin
                await DisplayAlert("Error", "You are not authorized to access admin features.", "OK");
            }
        }
        else
        {
            // Login failed
            await DisplayAlert("Error", "Invalid username or password.", "OK");
        }
    }
}