using System;
using System.Collections.Generic;
using System.Text;

namespace Novus.Models
{
    class Announcement
    {
        public string Unit { get; private set; }
        public string Title { get; private set; }
        public string Message { get; private set; }
        public DateTime Date { get; private set; }
        public string User { get; private set; }

        public Announcement(string unit, string title, string message, DateTime date, string user)
        {
            this.Unit = unit;
            this.Title = title;
            this.Message = message;
            this.Date = date;
            this.User = user;
        }

        public static Announcement[] GenerateAnnouncements(string unitCode, int returnArrayLength)
        {
            Announcement[] returnArray = new Announcement[returnArrayLength];
            string message = "Hello Students, This is a long test announcement to make sure that the list view expands on this assignment, no real information here as this is fake and Harry is just testing stuff, you know how it is sometimes haha, lol :-P";
            for(int i = 0; i< returnArrayLength; i++)
            {
                returnArray[i] = new Announcement(unitCode, unitCode + " Announcement", message, DateTime.Now, "Srikanth Nair");
            }
            return returnArray;
        }

    }
}
