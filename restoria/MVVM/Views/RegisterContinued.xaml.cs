using restoria.MVVM.Models;
using restoria.MVVM.Views;
using restoria.MVVM.ViewModels;

namespace restoria.MVVM.Views
{
    public partial class RegisterContinued : ContentPage
    {
        private User _user;

        public RegisterContinued(User user)
        {
            InitializeComponent();
            _user = user;

            // Use _user.FirstName and _user.LastName as needed
        }

        private async void OnExistingUserTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        private async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            _user.Email = emailEntry.Text;
            _user.Password = passwordEntry.Text;

            var databaseService = new DatabaseService();
            await databaseService.AddUserAsync(_user);

            // Navigate or show success message
        }
    }
}
