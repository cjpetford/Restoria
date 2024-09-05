using System;
using System.Collections.ObjectModel;
using restoria.MVVM.ViewModels.Base;
using restoria.MVVM.Models;
namespace restoria.MVVM.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        private readonly DatabaseService Database = new DatabaseService();

        public ObservableCollection<Doctor> Doctors { get; set; }

        private List<MedicineReminderModel> _reminderList;


        public List<MedicineReminderModel> ReminderList
        {
            get => _reminderList;

            set
            {
                if (_reminderList == value) return;
                _reminderList = value;
                OnPropertyChanged(nameof(ReminderList));
            }
        }

        public HomePageViewModel()
        {
            Doctors = new ObservableCollection<Doctor>();
            _reminderList = [];
            InitializeDatabase();
            InitList();
        }

        private async void InitializeDatabase()
        {
            await Database.InitializeAsync();
            // Load data from database if necessary
            var doctorsFromDb = await Database.GetDoctorsAsync();
            foreach (var doctor in doctorsFromDb)
            {
                Doctors.Add(doctor);
            }
        }

        private async void InitList()
        {
            ReminderList.Add(new MedicineReminderModel()
            {
                Medicine = "Acetaminophen",
                Dose = "10mg",
                Time = "Before launch 2:00 PM",
            });

            ReminderList.Add(new MedicineReminderModel()
            {
                Medicine = "Naproxen",
                Dose = "10mg",
                Time = "Before launch 2:10 PM",
            });

            if (!await Database.AnyDoctorsAsync())
            {
                await Database.InitializeAsync();

                // Add initial doctors
                var initialDoctors = new List<Doctor>
            {
                new Doctor { Name = "Dr. Gregory House", Qualifications = "All of them", Role = "Head of Diagnostics" }, 
                new Doctor { Name = "Dr. Allison Cameron", Qualifications = "Physiology & Immunology", Role = "Physicion & Immunologist" }, 
                new Doctor { Name = "Dr. Robert Chase", Qualifications = "Surgery", Role = "Surgeon" }, 
                new Doctor { Name = "Dr. Eric Foreman", Qualifications = "Neurology", Role = "Neurologist" }
            };

                foreach (var doctor in initialDoctors)
                {
                    Database.AddDoctorAsync(doctor);
                }

            }

        }

        public class MedicineReminderModel
        {
            public string Medicine { get; set; } = string.Empty;
            public string Dose { get; set; } = string.Empty;
            public string Time { get; set; } = string.Empty;
        }

    }
}

