using restoria.MVVM.ViewModels;

namespace restoria.MVVM.Views
{
    public partial class BookingPage : ContentPage
    {
        public BookingPage()
        {
            InitializeComponent();
            BindingContext = new BookingPageViewModel(new DatabaseService());
            datePicker.MinimumDate = DateTime.Today;
            datePicker.MaximumDate = DateTime.Today.AddDays(365);
        }
    }
}
