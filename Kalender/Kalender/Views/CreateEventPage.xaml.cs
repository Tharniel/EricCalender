using Kalender.Data;

namespace Kalender;

public partial class CreateEventPage : ContentPage
{
	public CreateEventPage()
	{
		InitializeComponent();
	}

    private void ClickedMakeTask(object sender, EventArgs e)
    {
        var user = Singletons.Authorized.GetAuthStatus().WhoIsUser();
        DateTime StartDate = MyDatePicker.Date;
        StartDate = new DateTime(StartDate.Year, StartDate.Month, StartDate.Day, 12, 0, 0);
        Models.Event newTask = new Models.Event
        {
            Title = MyInputTask.Text,
            Description = MyInputDescription.Text,
            StartDate = StartDate,
            Username = user,
        };
        var EventCollection = DB.TaskCollection();

        EventCollection.InsertOne(newTask);

        Navigation.PushAsync(new HomePage());
    }

}