using System;
using System.Collections.Generic;
using System.Text;
using Novus.Data;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Novus.Models
{
    public class Announcement
    {
        public int AnnouncementID { get; set; }
        public int UnitID { get; private set; }
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

        public AnnouncementDB ConvertToDB()
        {
            AnnouncementDB returnValue = new AnnouncementDB
            {
                AnnouncementID = this.AnnouncementID,
                UnitID = this.UnitID,
                Unit = this.Unit,
                Title = this.Title,
                Message = this.Message,
                Date = this.Date,
                User = this.User
            };

            return returnValue;
        }

    }
}
