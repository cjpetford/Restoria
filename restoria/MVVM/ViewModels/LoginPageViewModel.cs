using System.Windows.Input;
using restoria.MVVM.Views;
using restoria.MVVM.ViewModels.Base;

namespace restoria.MVVM.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        private readonly DatabaseService _database;

        public LoginPageViewModel(DatabaseService database)
        {
            _database = database;
        }

        public ICommand ICommandNavToHomePage => new Command(async () =>
        {
            var user = await _database.GetUserByEmailAndPasswordAsync("sample@example.com", "password");

            if (user != null)
            {
                if (user.Role == "Admin")
                {
                    // Navigate to Admin Page
                    await Application.Current.MainPage.Navigation.PushAsync(new AdminPage());
                }
                else
                {
                    // Navigate to Home Page
                    await Application.Current.MainPage.Navigation.PushAsync(new HomePage());
                }
            }
            else
            {
                // Show error
                await Application.Current.MainPage.DisplayAlert("Login Failed", "Invalid credentials", "OK");
            }
        });

    }
}
