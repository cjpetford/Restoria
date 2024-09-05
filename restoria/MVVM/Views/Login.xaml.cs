//using Microsoft.WindowsAppSDK.Runtime.Packages;
using Microsoft.Maui.Controls;
using BookingAppRestoria.MVVM.Models;
using BookingAppRestoria.Services;
using BookingAppRestoria.MVVM.Views;

namespace BookingAppRestoria.MVVM.Views;

public partial class Login : ContentPage
{
    private CaptchaGenerator captchaGenerator;

    private User _user;

    // =======================================
    // ========= DEFAULT CONSTRUCTOR =========

    public Login()
    {
        InitializeComponent();
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

    //====================================================
    //================ LOAD PRIVACY POLICY ===============
    private async void PrivacyPolicyTapped(object sender, EventArgs e)
    {
        // Navigate to the Privacy Policy page
        await Navigation.PushAsync(new PrivacyPolicy());
    }

    //========================================================
    //================ LOAD TERMS & CONDITIONS ===============
    private async void TermsTapped(object sender, EventArgs e)
    {
        // Navigate to the Privacy Policy page
        await Navigation.PushAsync(new TermsAndConditions());
    }

    private async void loginButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HomePage());
    }

    private async void OnExistingUserTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Login());
    }
}