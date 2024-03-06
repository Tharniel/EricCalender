namespace Kalender;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
		ChangeSignName();

    }

	private void ChangeSignName()
	{
        var user = Singletons.Authorized.GetAuthStatus().WhoIsUser();
		WelcomeLabel.Text = "Välkommen in " + user;
    }

    private async void OnClickedCalender(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CalenderPage());
    }

    private async void OnClickedCreateEvent(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreateEventPage());
    }

    private async void OnClickedPointBalance(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PointBalancePage());
    }

    private async void OnClickedPointStore(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreateEventPage());
    }
}