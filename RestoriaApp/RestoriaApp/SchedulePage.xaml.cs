namespace RestoriaApp;

public partial class SchedulePage : ContentPage
{
	public SchedulePage()
	{
		InitializeComponent();
	}

    private void Dashboard_Button(object sender, EventArgs e)
    {
        var dashboardpage = new DashboardPage();
        Navigation.PushAsync(dashboardpage);

    }

    private void Doctors_Button(object sender, EventArgs e)
    {
        var doctorspage = new DoctorsPage();
        Navigation.PushAsync(doctorspage);
    }

    private void Schedule_Button(object sender, EventArgs e)
    {
        var schedulepage = new SchedulePage();
        Navigation.PushAsync(schedulepage);
    }

    private void Profile_Button(object sender, EventArgs e)
    {
        var profilepage = new ProfilePage();
        Navigation.PushAsync(profilepage);
    }
}