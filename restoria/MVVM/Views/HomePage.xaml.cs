﻿using Microsoft.Maui.Controls;
using restoria.MVVM.ViewModels;

namespace restoria
{
    public partial class HomePage : TabbedPage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = new HomePageViewModel();
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

        // Example event handlers for button clicks
        private void Dashboard_Button(object sender, EventArgs e)
        {
            SwitchToDashboardTab();
        }

        private void Doctors_Button(object sender, EventArgs e)
        {
            SwitchToDoctorsTab();
        }

        private void Schedule_Button(object sender, EventArgs e)
        {
            SwitchToScheduleTab();
        }

        private void Profile_Button(object sender, EventArgs e)
        {
            SwitchToProfileTab();
        }
    }
}
