using System.Collections.ObjectModel;
using System.Windows.Input;
using BookingAppRestoria.Services;
using BookingAppRestoria.MVVM.Models;

namespace BookingAppRestoria.MVVM.Views;

public partial class AdminPage : ContentPage
{
    private readonly DatabaseService _databaseService;

    public ObservableCollection<Doctor> Doctors { get; set; }

    public ICommand EditDoctorCommand { get; }
    public ICommand DeleteDoctorCommand { get; }


    public AdminPage()
	{
		InitializeComponent();

        _databaseService = new DatabaseService();
        Doctors = new ObservableCollection<Doctor>();

    }

    private async void AddDoctor_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NewStaff());
    }

   
   
    private async void NewUser_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AdminLogin());
    }

}