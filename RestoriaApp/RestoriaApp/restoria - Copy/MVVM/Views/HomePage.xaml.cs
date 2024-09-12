using BookingAppRestoria.MVVM.ViewModels;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using BookingAppRestoria.Services;
using MauiTabbedPage = Microsoft.Maui.Controls.TabbedPage;
//using Android.Webkit;

namespace BookingAppRestoria.MVVM.Views;

public partial class HomePage : MauiTabbedPage
{
    private readonly DatabaseService _databaseService = new DatabaseService();

    private readonly HomePageViewModel _viewModel;

    public HomePage()
    {
        InitializeComponent();

        _viewModel = new HomePageViewModel();
        BindingContext = _viewModel;

        datePicker.MinimumDate = DateTime.Today;
        datePicker.MaximumDate = DateTime.Today.AddDays(365);

        MessagingCenter.Subscribe<NewStaff>(this, "DoctorAdded", async (sender) =>
        {
            // Reload doctors list when a new doctor is added
            await _viewModel.LoadDoctorsAsync();
        });
    }
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        // Unsubscribe from MessagingCenter when the page disappears to avoid memory leaks
        MessagingCenter.Unsubscribe<NewStaff>(this, "DoctorAdded");
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        // Refresh the doctors list when the page appears
        await _viewModel.LoadDoctorsAsync();
    }

    // Method to switch to the Doctors tab
    private void SwitchToDoctorsTab()
    {
        this.CurrentPage = this.Children[1]; // Index starts from 0, so 1 is the Doctors tab
    }

    // Method to switch to the Dashboard tab
    private void SwitchToDashboardTab()
    {
        this.CurrentPage = this.Children[0]; // Switch to the Dashboard tab
    }

    // Method to switch to the Schedule tab
    private void SwitchToScheduleTab()
    {
        this.CurrentPage = this.Children[2]; // Switch to the Schedule tab
    }

    // Method to switch to the Profile tab
    private void SwitchToProfileTab()
    {
        this.CurrentPage = this.Children[3]; // Switch to the Profile tab
    }

    private void Dashboard_Button(object sender, EventArgs e)
    {
        SwitchToDashboardTab(); // Switches to specified tab
    }

    private void Doctors_Button(object sender, EventArgs e)
    {
        SwitchToDoctorsTab(); // Switches to specified tab
    }

    private void Schedule_Button(object sender, EventArgs e)
    {
        SwitchToScheduleTab(); // Switches to specified tab
    }

    private void Profile_Button(object sender, EventArgs e)
    {
        SwitchToProfileTab(); // Switches to specified tab
    }

    private void OnMenuToggleClicked(object sender, EventArgs e)
    {
        MenuItems.IsVisible = !MenuItems.IsVisible;
    }

    private async void NavigateToTerms(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TermsAndConditions());
    }

    private async void NavigateToPrivacy(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PrivacyPolicy());
    }

    private async void NewFeature(object sender, EventArgs e)
    {
        // Display an alert to inform the user that a reset link has been sent
        await DisplayAlert("New Feature", "Add a new feature here", "Got it nigga?");
    }

    //private async void Booking_Button(object sender, EventArgs e)
    //{
    //    var selectedDoctor = doctorPicker.SelectedItem;
    //    var selectedDate = datePicker.Date;
    //    var selectedTime = timePicker.Time;

    //    if (selectedDoctor != null)
    //    {
    //        await DatabaseService.AddAppointmentAsync(selectedDoctor, selectedDate, selectedTime);
    //    }
    //    else
    //    {
    //        // Handle null doctor selection case
    //        await DisplayAlert("Error", "Please select a doctor.", "OK");
    //    }
    //}
}