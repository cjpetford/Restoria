using BookingAppRestoria.Services;
using BookingAppRestoria.MVVM.Models;
using Microsoft.Maui.Controls;

namespace BookingAppRestoria.MVVM.Views;

public partial class Login : ContentPage
{
    private CaptchaGenerator captchaGenerator;
    private readonly DatabaseService _databaseService;

    public Login()
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

    //================================================
    //================ PASSWORD FORGET ===============
    private async void OnForgotPasswordTapped(object sender, EventArgs e)
    {
        // Display an alert to inform the user that a reset link has been sent
        await DisplayAlert("Reset Password", "A link to has been sent to you email to reset your credentials.", "OK");
    }

    //===========================================
    //================ USER LOGIN ===============
    private async void OnLoginButton_Clicked(object sender, EventArgs e)
    {
        string email = emailEntry.Text;
        string password = passwordEntry.Text;

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            await DisplayAlert("Login Error", "Please enter both email and password.", "OK");
            return;
        }
        // ======================================
        // ========= CAPTCHA COMAPRISON =========
        else if (captchaEntry.Text != captchaLabel.Text)
        {
            await DisplayAlert("Registration Error", "CAPTCHA does not match!. Please try again", "OK");
            captchaEntry.BackgroundColor = Colors.Red;
            captchaEntry.Focus();
            return;
        }

        // Fetch user from the database
        var user = await _databaseService.GetUserByEmailAndPasswordAsync(email, password);

        if (user != null)
        {
            // Login successful, navigate to the homepage
            await Navigation.PushAsync(new HomePage());
        }
        else
        {
            // Login failed, show an error message
            await DisplayAlert("Login Error", "Invalid email or password. Please try again.", "OK");
        }
    }

    //=====================================================================
    //================ NON-REGISTERED USER TO REGISTER PAGE ===============
    private async void OnRegisterNowTapped(object sender, EventArgs e)
    {
        
        await Navigation.PushAsync (new Registration());
    }

    private async void Admin_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AdminLogin());
    }

}
