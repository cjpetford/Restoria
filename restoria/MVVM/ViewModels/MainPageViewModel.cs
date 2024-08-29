using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using System.Threading;
using System.Threading.Tasks;

namespace restoria.MVVM.Views
{
    public class MainPageViewModel : BindableObject
    {
        private ObservableCollection<string> onboardingList;
        private int position = 0;

        public ObservableCollection<string> OnboardingList
        {
            get => onboardingList;
            set
            {
                if (onboardingList != value)
                {
                    onboardingList = value;
                    OnPropertyChanged(nameof(OnboardingList));
                }
            }
        }

        public int Position
        {
            get => position;
            set
            {
                if (position != value)
                {
                    position = value;
                    OnPropertyChanged(nameof(Position));
                }
            }
        }

        public ICommand ICommandNavToLoginPage { get; set; }

        public MainPageViewModel()
        {
            onboardingList = new ObservableCollection<string>();
            ICommandNavToLoginPage = new Command(async () => await NavigateToLoginPageAsync());
            InitializeOnboardingList();
            CarouselRotateService();
        }

        private async Task NavigateToLoginPageAsync()
        {
            // Assuming you're navigating from a page; if not, adjust as needed
            var navigationPage = Application.Current?.MainPage as NavigationPage;
            if (navigationPage != null)
            {
                await navigationPage.Navigation.PushAsync(new LoginPage());
            }
        }

        private void InitializeOnboardingList()
        {
            OnboardingList.Add("untitled4.png");
            OnboardingList.Add("untitled4.png");
            OnboardingList.Add("untitled4.png");
            OnboardingList.Add("untitled4.png");
        }

        private async void CarouselRotateService()
        {
            if (OnboardingList != null && OnboardingList.Count != 0)
            {
                using var timer = new PeriodicTimer(TimeSpan.FromSeconds(5));
                while (await timer.WaitForNextTickAsync())
                {
                    Position = (Position + 1) % OnboardingList.Count;
                }
            }
        }
    }
}
