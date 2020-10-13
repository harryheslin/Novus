using Novus.Models;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novus.Data
{
    public class AnnouncementDB
    {
        [PrimaryKey, AutoIncrement]
        public int AnnouncementID { get; set; }

        [ForeignKey(typeof(UnitDB))]
        public int UnitID { get; set; }
        public string Unit { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public string User { get; set; }

        public Announcement ConvertToModel()
        {
            Announcement returnValue = new Announcement(this.Unit, this.Title, this.Message, this.Date, this.User);
            returnValue.AnnouncementID = this.AnnouncementID;
            return returnValue;
        }
    }
}
