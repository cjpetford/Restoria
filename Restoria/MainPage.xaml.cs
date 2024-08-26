namespace Restoria
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void PP_OkayButton_Clicked(object sender, EventArgs e)
        {
            // Code for closing page goes here
            // 'Pops' current page, taking user back to previous page. I think. - Jake 27/08/2022 10:57AM
            await Navigation.PopAsync();
        }
    }

}
