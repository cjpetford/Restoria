using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingAppRestoria.MVVM.Views;
using BookingAppRestoria.MVVM.ViewModels.Base;
using BookingAppRestoria.MVVM.Models;
using BookingAppRestoria.Services;

namespace BookingAppRestoria.MVVM.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        private readonly DatabaseService _databaseService = new DatabaseService();

        public ObservableCollection<Doctor> Doctors { get; set; }


        public HomePageViewModel()
        {
            _databaseService = new DatabaseService();

            Doctors = new ObservableCollection<Doctor>();       

            //InitList();
        }

        public async Task LoadDoctorsAsync()
        {
            var doctorsFromDb = await _databaseService.GetDoctorsAsync();

            // Clear the existing list and add doctors dynamically
            Doctors.Clear();

            foreach (var doctor in doctorsFromDb)
            {
                Doctors.Add(doctor);
            }
        }

        //private async void InitList()
        //{
        //    if (!await _databaseService.AnyDoctorsAsync()) // If DB = null then add doctors listed below
        //    {
                
        //         //=================================
        //         //====== ADD INITIAL DOCTORS ======
        //        var initialDoctors = new List<Doctor>
        //        {
        //            new Doctor
        //            {
        //                Name = "Dr. Gregory House",
        //                Qualifications = "PhD MD MBBS MBA MSc",
        //                Role = "Head of Diagnostics"
        //            },
        //            new Doctor
        //            {
        //                Name = "Dr. Allison Cameron",
        //                Qualifications = "MBBS MD MSc FRCPath",
        //                Role = "Physicion & Immunologist"
        //            },
        //            new Doctor
        //            {
        //                Name = "Dr. Robert Chase",
        //                Qualifications = "MRCPCH PhD MBBS MD",
        //                Role = "Pediatrician"
        //            },
        //            new Doctor
        //            {
        //                Name = "Dr. Eric Foreman",
        //                Qualifications = "MBBS MD MSc DO GPEP",
        //                Role = "General Practitioner (GP)"
        //            },

        //    };


        //        foreach (var doctor in initialDoctors)
        //        {
        //            _databaseService.SaveDoctorAsync(doctor);
        //        }

        //    }
        }

    }



    

