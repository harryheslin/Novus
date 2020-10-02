using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Text;
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

        public Events(string EventName, string EventDescription, DateTime StartDate, DateTime EndDate, String EventColour, bool IsAllDay)
        {
            this.EventName = EventName;
            this.EventDescription = EventDescription;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.EventColour = EventColour;
            this.IsAllDay = IsAllDay;
        }

        public  void AddToEvents()
        {
            Appointments = new ObservableCollection<Appointment>
            {
                new Appointment
                {
                    Title = EventName,
                    Detail = EventDescription,
                    StartDate = StartDate,
                    EndDate = EndDate,
                    Color = Color.Green,
                    IsAllDay = IsAllDay
                }
            };
            //Console.WriteLine(StartDate);
            //Console.WriteLine(EndDate);
        }

        public static ObservableCollection<Appointment> Appointments { get; set; }
        
    }
}
