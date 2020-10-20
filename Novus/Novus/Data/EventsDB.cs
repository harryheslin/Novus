using System;
using System.Collections.Generic;
using System.Text;
using SQLiteNetExtensions.Attributes;
using SQLite;
using Novus.Models;

namespace Novus.Data
{
    public class EventsDB
    {
        [PrimaryKey, AutoIncrement]
        public int EventID { get; set; }

        [ForeignKey(typeof(StudentDB))]
        public int StudentID { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string EventColour { get; set; }
        public bool IsAllDay { get; set; }
        public Events ConvertToModel()
        {
            Events returnValue = new Events(EventID, EventName,EventDescription,StartDate,EndDate,EventColour,IsAllDay)
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
    }
}
