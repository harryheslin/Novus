using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using Telerik.Windows.Documents.Spreadsheet.Expressions;
using Telerik.XamarinForms.Input;

namespace Novus.Models
{
    class Events
    {
        public string EventName { get; private set; }
        public string EventDescription { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string EventColour { get; private set; }
        public bool IsAllDay { get; private set; }

        public int numEvents = 0;

        /*public Events(string EventName, string EventDescription, DateTime StartDate, DateTime EndDate, String EventColour, bool IsAllDay)
        {
            this.EventName = EventName;
            this.EventDescription = EventDescription;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.EventColour = EventColour;
            this.IsAllDay = IsAllDay;
        }*/

        public static List<string> TitleList = new List<string>();
        public static List<string> DetailList = new List<string>();
        public static List<DateTime> StartDateList = new List<DateTime>();
        public static List<DateTime> EndDateList = new List<DateTime>();
        public static List<String> ColourList = new List<string>();
        public static List<bool> IsAllDayList = new List<bool>();

        public static void AddToEvents(string EventName, string EventDescription, DateTime StartDate, DateTime EndDate, String EventColour, bool IsAllDay)
        {
            TitleList.Add(EventName);
            DetailList.Add(EventDescription);
            StartDateList.Add(StartDate);
            EndDateList.Add(EndDate);
            ColourList.Add(EventColour);
            IsAllDayList.Add(IsAllDay);

            for (int i = 0; i < TitleList.Count; i++)
            {
                Console.WriteLine(TitleList.Count);
              
            }
            Appointments = new ObservableCollection<Appointment>();
            for (int a = 0; a < TitleList.Count; a++)
            {
                Appointments.Add(new Appointment { 
                    Title = TitleList[a],
                    Detail = DetailList[a],
                    StartDate=StartDateList[a],
                    EndDate=EndDateList[a],
                    Color=ColourDeterminer(ColourList[a]),
                    IsAllDay= IsAllDayList[a]
                });                
            }            
        }

        public static ObservableCollection<Appointment> Appointments { get; set; }

        public static Color ColourDeterminer(string colour)
        {
            Color eventColour;            
            if (colour == "Red")
            {
                eventColour = Color.Red;
            }
            else if (colour == "Blue")
            {
                eventColour = Color.Blue;
            }
            else if (colour == "Yellow")
            {
                eventColour = Color.Yellow;
            }
            else if (colour == "Pink")
            {
                eventColour = Color.Pink;
            }
            else if (colour == "Orange")
            {
                eventColour = Color.Orange;
            }
            else if (colour == "Green")
            {
                eventColour=Color.Green;
            }          
            return eventColour;
        }
        
    }
}
