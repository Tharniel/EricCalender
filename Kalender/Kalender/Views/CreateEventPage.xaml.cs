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
        Models.Event newTask = new Models.Event
        {
            Title = MyInputTask.Text,
            Description = MyInputDescription.Text,
            StartDate = MyDatePicker.Date,
            Username = user,
        };
        var EventCollection = DB.TaskCollection();

        EventCollection.InsertOne(newTask);
    }
}