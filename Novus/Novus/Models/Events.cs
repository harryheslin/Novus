using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using Telerik.XamarinForms.Input;
using SQLiteNetExtensions.Attributes;
using Novus.Data;

namespace Novus.Models
{
    public class Events
    {
        public int EventID { get; set; }
        public int StudentID { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string EventColour { get; set; }
        public bool IsAllDay { get; set; }

        private static List<string> TitleList = new List<string>();
        private static List<string> DetailList = new List<string>();
        private static List<DateTime> StartDateList = new List<DateTime>();
        private static List<DateTime> EndDateList = new List<DateTime>();
        private static List<String> ColourList = new List<string>();
        private static List<bool> IsAllDayList = new List<bool>();


        /*public Events(string EventName, string EventDescription, DateTime StartDate, DateTime EndDate, String EventColour, bool IsAllDay)
        {
            this.EventName = EventName;
            this.EventDescription = EventDescription;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.EventColour = EventColour;
            this.IsAllDay = IsAllDay;
        }*/

        public EventsDB ConvertToDB()
        {
            EventsDB returnValue = new EventsDB
            {
                EventID = this.EventID,
                StudentID = this.StudentID,
                EventName = this.EventName,
                EventDescription = this.EventDescription,
                StartDate = this.StartDate,
                EndDate = this.EndDate,
                EventColour = this.EventColour,
                IsAllDay = this.IsAllDay
            };

            return returnValue;
        }

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
            StartDateList.Add(EventStartDate);
            EndDateList.Add(EventEndDate);
            ColourList.Add(EventColour);
            IsAllDayList.Add(EventIsAllDay);
            Appointments = new ObservableCollection<Appointment>();

            for (int a = 0; a < TitleList.Count; a++)
            {
                Appointments.Add(new Appointment
                {
                    Title = TitleList[a],
                    Detail = DetailList[a],
                    StartDate = StartDateList[a],
                    EndDate = EndDateList[a],
                    Color = ColourDeterminer(ColourList[a]),
                    IsAllDay = IsAllDayList[a]
                });
            }
        }

        public static ObservableCollection<Appointment> Appointments { get; set; }

        //determine the colour given the input from the list
        public static Color ColourDeterminer(string colour)
        {
            if (colour == "Red")
            {
                return Color.Red;
            }
            else if (colour == "Blue")
            {
                return Color.Blue;
            }
            else if (colour == "Yellow")
            {
                return Color.Yellow;
            }
            else if (colour == "Pink")
            {
                return Color.Pink;
            }
            else if (colour == "Orange")
            {
                return Color.Orange;
            }
            else if (colour == "Green")
            {
                return Color.Green;
            }
            else
            {
                return Color.White;
            }
        }
    }
}
