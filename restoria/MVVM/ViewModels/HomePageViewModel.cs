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
        public ObservableCollection<Appointment> Appointments { get; set; }


        public HomePageViewModel()
        {
            Doctors = new ObservableCollection<Doctor>();
            Appointments = new ObservableCollection<Appointment>();
            InitializeDatabase();
            InitList();
        }

        private async void InitializeDatabase() // Initialise databasea and check if any dotors need to be added
        {
            await Database.InitializeDoctorsAsync();
            // Load data from database if necessary
            var doctorsFromDb = await Database.GetDoctorsAsync();
            foreach (var doctor in doctorsFromDb)
                Doctors.Add(doctor);


            await Database.InitializeAppointmentsAsync();

            var appointmentsFromDb = await Database.GetAppointmentsAsync();
            foreach (var appointment in appointmentsFromDb)
            {
                Appointments.Add(appointment);
            }
        }

        private async void InitList()
        {
            if (!await Database.AnyDoctorsAsync()) // If DB = null then add doctors listed below
            {
                await Database.InitializeDoctorsAsync();

                // Add initial doctors
                var initialDoctors = new List<Doctor>
                {
                    new Doctor { Name = "Dr. Gregory House", Qualifications = "All of them", Role = "Head of Diagnostics" }, 
                    new Doctor { Name = "Dr. Allison Cameron", Qualifications = "Physiology & Immunology", Role = "Physicion & Immunologist" }, 
                    new Doctor { Name = "Dr. Robert Chase", Qualifications = "Surgery", Role = "Surgeon" }, 
                    new Doctor { Name = "Dr. Eric Foreman", Qualifications = "Neurology", Role = "Neurologist" }
                };

                foreach (var doctor in initialDoctors)
                    await Database.AddDoctorAsync(doctor);
            }

            if (!await Database.AnyAppointmentsAsync())
            {
                await Database.InitializeAppointmentsAsync();

                foreach (var doctor in Doctors)
                {
                    var initialAppointments = new List<Appointment>
                    {
                        new Appointment { doctorId = doctor.Id, AppointmentDate = DateTime.Today.AddHours(9) },
                        new Appointment { doctorId = doctor.Id, AppointmentDate = DateTime.Today.AddHours(10) },
                        new Appointment { doctorId = doctor.Id, AppointmentDate = DateTime.Today.AddHours(11) },
                        new Appointment { doctorId = doctor.Id, AppointmentDate = DateTime.Today.AddHours(12) },
                        new Appointment { doctorId = doctor.Id, AppointmentDate = DateTime.Today.AddHours(13) },
                        new Appointment { doctorId = doctor.Id, AppointmentDate = DateTime.Today.AddHours(14) },
                        new Appointment { doctorId = doctor.Id, AppointmentDate = DateTime.Today.AddHours(15) },
                        new Appointment { doctorId = doctor.Id, AppointmentDate = DateTime.Today.AddHours(16) },
                    };

                    foreach (var appointments in initialAppointments)
                        await Database.AddAppointmentAsync(appointments);
                }
            }
        }
            
        private async void PurgeOldAppointments()
        {
            foreach (var appointments in Appointments)
                if (appointments.AppointmentDate <= DateTime.Now)
                    await Database.RemoveAppointmentAsync(appointments);
        }

        public async void UpdateAppointmentsListPerDoctor(Doctor doctor)
        {
            var appointments = await Database.GetAppointmentsAsync();
            foreach (var appointment in appointments)
                if (doctor.Id == appointment.doctorId)
                    Appointments.Add(appointment);
        }
    }
}

