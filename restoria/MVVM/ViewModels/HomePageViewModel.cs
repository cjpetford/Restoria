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


        public HomePageViewModel()
        {
            Doctors = new ObservableCollection<Doctor>();
            InitializeDatabase();
            InitList();
        }

        private async void InitializeDatabase() // Initialise databasea and check if any dotors need to be added
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
            if (!await Database.AnyDoctorsAsync()) // If DB = null then add doctors listed below
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
    }
}

