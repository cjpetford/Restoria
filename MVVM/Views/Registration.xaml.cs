//using Microsoft.WindowsAppSDK.Runtime.Packages;
using BookingAppRestoria.MVVM.Models;

namespace BookingAppRestoria.MVVM.Views;

public partial class Registration : ContentPage
{
    
    private CaptchaGenerator captchaGenerator;

    private User _user;

    // =======================================
    // ========= DEFAULT CONSTRUCTOR =========
    public Registration() : this(new User()) 
    {

    }

    public Registration(User user)
	{
		InitializeComponent();

        dobPicker.MaximumDate = DateTime.Now;
        dobPicker.MinimumDate = DateTime.Now.AddYears(-150);

        captchaGenerator = new CaptchaGenerator();
        GenerateNewCaptcha();

        _user = user ?? new User();
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

     //================================================
     //================ FORM VALIDATION ===============
    private async void signupButton_Clicked(object sender, EventArgs e)
    {
        // ============================================
        // ========= RESET BACKGROUND COLOURS =========
        firstNameEntry.BackgroundColor = Colors.Transparent;
        lastNameEntry.BackgroundColor = Colors.Transparent;
        emailEntry.BackgroundColor = Colors.Transparent;
        contactEntry.BackgroundColor = Colors.Transparent;
        dobPicker.BackgroundColor = Colors.Transparent;
        passwordEntry1.BackgroundColor = Colors.Transparent;
        passwordEntry2.BackgroundColor = Colors.Transparent;
        captchaEntry.BackgroundColor = Colors.Transparent;
        privacyPolicyCheckBox.BackgroundColor = Colors.Transparent;
        termsCheckBox.BackgroundColor = Colors.Transparent;

        // =========================================
        // ========= FIRST NAME VALIDATION =========
        if (string.IsNullOrEmpty(firstNameEntry.Text)) 
        {
            await DisplayAlert("Registration Error", "First Name is Required.", "OK");
            firstNameEntry.BackgroundColor = Colors.Red;
            firstNameEntry.Focus();
            return;
        }

        // ========================================
        // ========= LAST NAME VALIDATION =========
        else if (string.IsNullOrEmpty(lastNameEntry.Text))
        {
            await DisplayAlert("Registration Error", "Last Name is Required.", "OK");
            firstNameEntry.BackgroundColor = Colors.Transparent;
            lastNameEntry.BackgroundColor = Colors.Red;
            lastNameEntry.Focus();
            return;
        }

        // ============================================
        // ========= EMAIL ADDRESS VALIDATION =========
        else if (string.IsNullOrEmpty(emailEntry.Text))
        {
            await DisplayAlert("Registration Error", "Email Address is Required.", "OK");
            lastNameEntry.BackgroundColor = Colors.Transparent;
            emailEntry.BackgroundColor = Colors.Red;
            emailEntry.Focus();
            return;
        }

        // =============================================
        // ========= CONTACT NUMBER VALIDATION =========
        else if (string.IsNullOrEmpty(contactEntry.Text) || !contactEntry.Text.All(char.IsDigit))
        {
            await DisplayAlert("Registration Error", "Contact Phone Number is Required & should be Numeric", "OK");
            emailEntry.BackgroundColor = Colors.Transparent;
            contactEntry.BackgroundColor = Colors.Red;
            contactEntry.Focus();
            return;
        }

        // ==================================
        // ========= DOB VALIDATION =========
        else if (dobPicker.Date == DateTime.Now)
        {
            await DisplayAlert("Registration Error", "Date of Birth is Required.", "OK");
            contactEntry.BackgroundColor = Colors.Transparent;
            dobPicker.BackgroundColor = Colors.Red;
            dobPicker.Focus();
            return;
        }

        // ===========================================
        // ========= SET PASSWORD VALIDATION =========
        else if (string.IsNullOrEmpty(passwordEntry1.Text))
        {
            await DisplayAlert("Registration Error", "Credentials is Required.", "OK");
            dobPicker.BackgroundColor = Colors.Transparent;
            passwordEntry1.BackgroundColor = Colors.Red;
            passwordEntry1.Focus();
            return;
        }

        // ===============================================
        // ========= CONFIRM PASSWORD VALIDATION =========
        else if (string.IsNullOrEmpty(passwordEntry2.Text))
        {
            await DisplayAlert("Registration Error", "Please confirm entered Password.", "OK");
            passwordEntry1.BackgroundColor = Colors.Transparent;
            passwordEntry2.BackgroundColor = Colors.Red;
            passwordEntry2.Focus();
            return;
        }

        // ===============================================
        // ========= COMPARE PASSWORD VALIDATION =========
        else if (passwordEntry2.Text != passwordEntry1.Text)
        {
            await DisplayAlert("Registration Error", "Credentials do not match!. Please try again", "OK");
            passwordEntry1.BackgroundColor = Colors.Transparent;
            passwordEntry2.BackgroundColor = Colors.Red;
            passwordEntry2.Focus();
            return;
        }

        // ======================================
        // ========= CAPTCHA COMAPRISON =========
        else if (captchaEntry.Text != captchaLabel.Text)
        {
            await DisplayAlert("Registration Error", "CAPTCHA does not match!. Please try again", "OK");
            passwordEntry2.BackgroundColor = Colors.Transparent;
            captchaEntry.BackgroundColor = Colors.Red;
            captchaEntry.Focus();
            return;
        }

        // ============================================
        // ========= PRIVACY POLICY AGREEMENT =========
        else if(!privacyPolicyCheckBox.IsChecked)
        {
            await DisplayAlert("Agreement Required", "Please kindly agree to the PRIVACY POLICY before proceeding", "OK");
            captchaEntry.BackgroundColor = Colors.Transparent;
            privacyPolicyCheckBox.BackgroundColor = Colors.Red;
            privacyPolicyCheckBox.Focus();
            return;
        }

        // ================================================
        // ========= TERMS & CONDITIONS AGREEMENT =========
        else if (!termsCheckBox.IsChecked)
        {
            await DisplayAlert("Agreement Required", "Please kindly agree to the TERMS & CONDITIONS before proceeding", "OK");
            privacyPolicyCheckBox.BackgroundColor = Colors.Transparent;
            termsCheckBox.BackgroundColor = Colors.Red;
            termsCheckBox.Focus();
            return;
        }

        // ================================================
        // ========= SAVE ALL INPUT IN DATABASE ===========
        else
        {
            _user.FirstName = firstNameEntry.Text;
            _user.LastName = lastNameEntry.Text;
            _user.Email = emailEntry.Text;
            _user.Password = passwordEntry1.Text;
            _user.DOB = dobPicker.Date;
            _user.Contact = int.Parse(contactEntry.Text);
            _user.Conditions = conditionEntry.Text;

            //var databaseService = new DatabaseService();
            //await databaseService.AddUserAsync(_user);


        }
    }

    private async void OnExistingUserTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Login());
    }
}