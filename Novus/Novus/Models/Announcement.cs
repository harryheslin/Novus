using System;
using System.Collections.Generic;
using System.Text;

namespace Novus.Models
{
    class Announcement
    {
        public String Unit { get; private set; }
        public String Title { get; private set; }
        public String Message { get; private set; }
        public DateTime Date { get; private set; }
        public String User { get; private set; }

        public Announcement(String unit, String title, String message, DateTime date, String user)
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
            for(int i = 0; i< returnArrayLength; i++)
            {
                returnArray[i] = new Announcement(unitCode, unitCode + " Announcement", "Test Announcement", DateTime.Now, "Srikanth Nair");
            }
            return returnArray;
        }

    }
}
