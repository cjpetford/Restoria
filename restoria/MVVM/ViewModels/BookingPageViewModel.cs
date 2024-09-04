using restoria.MVVM.Models;
using restoria.MVVM.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restoria.MVVM.ViewModels
{
    public class BookingPageViewModel : BaseViewModel
    {
        private readonly DatabaseService _database;
        public ObservableCollection<Doctor> DoctorOptions { get; set; }
        private string _selectedDoctor;
        public string SelectedDoctor
        {
            get => _selectedDoctor;
            set
            {
                if (_selectedDoctor != value)
                {
                    _selectedDoctor = value;
                    OnPropertyChanged(nameof(SelectedDoctor));
                }
            }
        }
        private DateTime _selectedDate;

        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                if (_selectedDate != value)
                {
                    _selectedDate = value;
                    OnPropertyChanged(nameof(SelectedDate));
                }
            }
        }

        private TimeSpan _selectedTime;
        public TimeSpan MinimumTime { get; set; } = TimeSpan.FromMinutes(510);
        public TimeSpan MaximumTime { get; set; } = TimeSpan.FromHours(17);
        public TimeSpan SelectedTime
        {
            get => _selectedTime;
            set
            {
                if (_selectedTime != value)
                {
                    _selectedTime = value;
                    OnPropertyChanged(nameof(SelectedTime));
                }
            }
        }

        public BookingPageViewModel(DatabaseService database)
        {
            _database = database;
            DoctorOptions = new ObservableCollection<Doctor>
            {
                new Doctor { Id = 1, Name = "Dr. Gregory House", Qualifications = "All of them", Role = "Head of Diagnostics"},
                new Doctor { Id = 2, Name = "Dr. Allison Cameron", Qualifications = "Physiology & Immunology", Role = "Physicion & Immunologist"},
                new Doctor { Id = 3, Name = "Dr. Robert Chase", Qualifications = "Surgery", Role = "Surgeon"},
                new Doctor { Id = 4, Name = "Dr. Eric Foreman", Qualifications = "Neurology", Role = "Neurologist"}
            };
            SelectedDate = DateTime.Today;
            SelectedTime = TimeSpan.FromMinutes(510);
            LoadDoctors();
        }

        private async Task LoadDoctors()
        {
            var doctorList = await _database.GetDoctorsAsync();
            foreach (var doctor in doctorList)
            {
                DoctorOptions.Add(doctor);
            }
        }
    }
}
