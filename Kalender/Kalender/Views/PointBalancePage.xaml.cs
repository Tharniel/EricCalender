namespace Kalender;

public partial class PointBalancePage : ContentPage
{
	public PointBalancePage()
	{
		InitializeComponent();
        ChangeSignName();
        ChangeBalance();
    }
    private void ChangeSignName()
    {
        var user = Singletons.Authorized.GetAuthStatus().WhoIsUser();
        WelcomeLabel.Text = "Välkommen in " + user + " till dina poäng!";
    }
    private async void ChangeBalance()
    {
        var users = await Data.DB.GetPointsFromDB();
        var user = users.FirstOrDefault();
        if (user != null)
        {
            var points = user.Points.GetValueOrDefault();
            UserPointBalance.Text = "Dina poäng är: " + points;
        }
    }     
}