﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
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


        private static List<string> TitleList = new List<string>();
        private static List<string> DetailList = new List<string>();
        private static List<DateTime> StartDateList = new List<DateTime>();
        private static List<DateTime> EndDateList = new List<DateTime>();
        private static List<String> ColourList = new List<string>();
        private static List<bool> IsAllDayList = new List<bool>();

        public static void AddToEvents(string EventName, string EventDescription, DateTime EventStartDate, DateTime EventEndDate, String EventColour, bool EventIsAllDay)
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
                eventColour = Color.Green;
            }
            return eventColour;
        }

    }
}
