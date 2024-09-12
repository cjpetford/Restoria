using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BookingAppRestoria.Services;
using BookingAppRestoria.MVVM.Models;
using BookingAppRestoria.MVVM.ViewModels;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BookingAppRestoria.MVVM.ViewModels
{
    public class NewStaffViewModel : INotifyPropertyChanged
    {
        private readonly DatabaseService _databaseService;

        public ObservableCollection<Doctor> Doctors { get; set; }
        public ICommand EditDoctorCommand { get; }
        public ICommand DeleteDoctorCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;



        public NewStaffViewModel()
        {
            _databaseService = new DatabaseService();

            Doctors = new ObservableCollection<Doctor>();
            EditDoctorCommand = new Command<Doctor>(OnEditDoctor);
            DeleteDoctorCommand = new Command<Doctor>(OnDeleteDoctor);

            LoadDoctors();
        }

        private async void LoadDoctors()
        {
            var doctors = await _databaseService.GetDoctorsAsync();
            foreach (var doctor in doctors)
            {
                Doctors.Add(doctor);
            }
        }

        private async void OnEditDoctor(Doctor doctor)
        {
            // Handle editing of the doctor
            await Application.Current.MainPage.DisplayAlert("Edit Doctor", $"Editing {doctor.Name}", "OK");
        }

        private async void OnDeleteDoctor(Doctor doctor)
        {
            // Handle deleting of the doctor from the database and remove from collection
            var confirmed = await Application.Current.MainPage.DisplayAlert("Confirm Delete", $"Are you sure you want to delete {doctor.Name}?", "Yes", "No");
            if (confirmed)
            {
                await _databaseService.DeleteDoctorAsync(doctor);
                Doctors.Remove(doctor);
            }
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //public void UpdateDoctor(Doctor doctor)
        //{
        //    // Assuming you have a method to update the doctor in your database service
        //    _databaseService.UpdateDoctorAsync(doctor);

        //    // Notify collection change if necessary
        //    OnPropertyChanged(nameof(Doctors));
        //}


        public async void SaveDoctor(Doctor doctor)
        {
            var result = await _databaseService.SaveDoctorAsync(doctor);

            if (result > 0)
            {
                // Notify that changes were successful
                OnPropertyChanged(nameof(Doctors));
                // Optionally notify user of success
                await Application.Current.MainPage.DisplayAlert("Success", "Doctor saved successfully", "OK");
            }
            else
            {
                // Handle failure
                await Application.Current.MainPage.DisplayAlert("Error", "Failed to save doctor", "OK");
            }
        }
    }

}
