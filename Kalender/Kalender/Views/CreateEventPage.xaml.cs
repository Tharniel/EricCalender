using Kalender.Data;
using Kalender.Views;

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
        var recurringFrequency = RecurrencePicker.SelectedItem.ToString();
        var recurringRate = int.Parse(NumberEntry.Text);

        if (RecurringCheckBox.IsChecked == true)
        {
            var totalEvents = int.Parse(NumberOfEventsEntry.Text);
            for (int i = 0; i < totalEvents; i++)
            {
                DateTime nextEventDate;
                switch (recurringFrequency)
                {
                    case "Dagar":
                        nextEventDate = StartDate.AddDays(recurringRate * i);
                        break;
                    case "Veckor":
                        nextEventDate = StartDate.AddDays(7 * recurringRate * i);
                        break;
                    case "Månader":
                        nextEventDate = StartDate.AddMonths(recurringRate * i);
                        break;
                    default:
                        Navigation.PushAsync(new ErrorPage());
                        return;
                }

                Models.Event newTask = new Models.Event
                {
                    Title = MyInputTask.Text,
                    Description = MyInputDescription.Text,
                    StartDate = nextEventDate,
                    Username = user,
                };
                var EventCollection = DB.TaskCollection();
                EventCollection.InsertOne(newTask);
            }

            Navigation.PushAsync(new HomePage());
        }
        else
        {
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

    private void OnRecurringCheckBoxChecked(object sender, CheckedChangedEventArgs e)
    {
        bool isChecked = e.Value;
        RecurrencePicker.IsVisible = isChecked;
        NumberEntry.IsVisible = isChecked;
    }
}