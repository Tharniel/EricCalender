using Amazon.Runtime.Internal.Transform;
using Amazon.SecurityToken.Model;
using Kalender.Models;
using Plugin.Maui.Calendar.Models;
using System.Data;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Kalender;

public partial class CalenderPage : ContentPage
{
    public EventCollection Events { get; set; }
    public CalenderPage()
    {
        InitializeComponent();
        InitializeEvents();
    }
    private async void InitializeEvents()
    {

        //förstår ej hela den här koden då den har mycket saker som är kopierat och inte riktigt förklarat 
        //Tar in alla events från db och EventCollections som är någon konstigt dictionary med datetime och icollection som ska låta en lägga till Datetime.
        //ContainsKey kollar ifall datumet redan finns i kalendern ifall det inte finns så gör den en ny list? av events annars lägger till eventen i samma lista
        // men funkar? idk i am scared
        //plugin Github: https://github.com/yurkinh/Plugin.Maui.Calendar/tree/main
        var dbEvents = await Data.DB.GetEventsFromDB();
        Events = new EventCollection();
        foreach (var dbEvent in dbEvents)
        {
            var eventDate = dbEvent.StartDate.GetValueOrDefault().Date;
            var year = eventDate.Year;
            var month = eventDate.Month;
            var day = eventDate.Day;
            var dateKey = new DateTime(year, month, day);

            if (Events.ContainsKey(dateKey))
            {
                ((List<Event>)Events[dateKey]).Add(new Event { Title = dbEvent.Title, Description = dbEvent.Description });
            }
            else
            {
                Events[dateKey] = new List<Event>()
            {
                new Event { Title = dbEvent.Title, Description = dbEvent.Description }
            };
            }
        }
        BindingContext = this;
    }

}
