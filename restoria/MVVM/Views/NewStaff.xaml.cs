using BookingAppRestoria.Services;
using BookingAppRestoria.MVVM.Models;
using BookingAppRestoria.MVVM.ViewModels;
using System;
using Microsoft.Maui.Controls;

namespace BookingAppRestoria.MVVM.Views;

public partial class NewStaff : ContentPage
{
    private readonly DatabaseService _databaseService;

    private Doctor _selectedDoctor;

    public NewStaff()
	{
		InitializeComponent();

        _databaseService = new DatabaseService();
        BindingContext = new NewStaffViewModel();
    }

    private async void NewStaff_Clicked(object sender, EventArgs e)
    {
        // Read input values
        var name = nameEntry.Text;
        var specialty = specialtyEntry.Text;
        var qualifications = qualificationsEntry.Text;

        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(specialty) || string.IsNullOrWhiteSpace(qualifications))
        {
            await DisplayAlert("Data Entry Error", "Please fill out all fields accordingly.", "OK");
            return;
        }

        // Create a new doctor instance
        var newDoctor = new Doctor
        {
            Name = name,
            Role = specialty, // Used for specialty
            Qualifications = qualifications
        };

        try
        {
            // Add the new doctor to the database
            await _databaseService.SaveDoctorAsync(newDoctor);

            // Optionally, show a success message
            await DisplayAlert("WHOOP WHOOP", "New Staff Memmber Added Successfully!", "YIIPPEEEE");

            // Clear the input fields
            nameEntry.Text = string.Empty;
            specialtyEntry.Text = string.Empty;
            qualificationsEntry.Text = string.Empty;

            await Navigation.PushAsync(new HomePage());
        }

        catch (Exception ex)
        {
            // Handle potential errors
            await DisplayAlert("Error", $"An error occurred while saving the doctor: {ex.Message}", "OK");
        }
    }

    private async void SaveChanges_Clicked(object sender, EventArgs e)
    {
        if (_selectedDoctor != null)
        {
            _selectedDoctor.Name = editNameEntry.Text;
            _selectedDoctor.Role = editSpecialtyEntry.Text;
            _selectedDoctor.Qualifications = editQualificationsEntry.Text;

            // Notify ViewModel to save changes to the database
            var viewModel = (NewStaffViewModel)BindingContext;
            viewModel.SaveDoctor(_selectedDoctor);

            // Hide editing form
            EditingForm.IsVisible = false;
        }
    }

    private void CancelEdit_Clicked(object sender, EventArgs e)
    {
        // Hide editing form without saving changes
        EditingForm.IsVisible = false;
    }

    private void OnEditDoctor(Doctor doctor)
    {
        _selectedDoctor = doctor;

        // Populate the editing form with selected doctor's details
        editNameEntry.Text = doctor.Name;
        editSpecialtyEntry.Text = doctor.Role;
        editQualificationsEntry.Text = doctor.Qualifications;

        // Show the editing form
        EditingForm.IsVisible = true;
    }
}