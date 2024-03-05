namespace Kalender
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        private async void OnClickedSignIn(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        private async void OnClickedRegister(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registered());
        }
        private async void OnClickedCalender(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CalenderPage());
        }
    }
    public static class GlobalSettings
    {
        public static string SomeGlobalProperty { get; set; } = "Initial Value";
        public static string Username { get; set; } = "null";
    }
}
