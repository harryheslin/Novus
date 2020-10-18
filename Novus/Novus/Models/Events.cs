using System;
using System.Collections.Generic;
using System.Drawing;
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

        public Events(int eventNum, string EventName, string EventDescription, DateTime StartDate, DateTime EndDate, String EventColour, bool IsAllDay)
        {
            this.EventID = eventNum;
            this.StudentID = App.Student.StudentID;
            this.EventName = EventName;
            this.EventDescription = EventDescription;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.EventColour = EventColour;
            this.IsAllDay = IsAllDay;
        }

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
