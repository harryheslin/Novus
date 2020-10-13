using System;
using System.Collections.Generic;
using System.Text;
using Novus.Models;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Novus.Data
{
    public class ClassDB
    {
        [PrimaryKey, AutoIncrement]
        public int ClassID { get; set; }

        [ForeignKey(typeof(UnitDB))]
        public int UnitID { get; set; }

        [ForeignKey(typeof(SemesterDB))]
        public int SemesterID { get; set; }
        public ClassType Type { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string DisplayTime { get; set; }
        public ClassMode Mode { get; set; }
        public string DisplayMode { get; set; }
        public string Room { get; set; }
        public bool Registerd { get; set; }
        public bool Planned { get; set; }
        public string Tag { get; set; }

        public Class ConvertToModel()
        {
            Class returnValue = new Class(this.Type, this.DayOfWeek, this.StartTime, this.EndTime, this.Mode, this.Room);
            returnValue.ClassID = this.ClassID;
            returnValue.UnitID = this.UnitID;
            returnValue.SemesterID = this.SemesterID;
            return returnValue;
        }
    }
}
