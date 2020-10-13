using Novus.Models;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novus.Data
{
    public class AssesmentDB
    {
        [PrimaryKey, AutoIncrement]
        public int AssesmentID { get; set; }

        [ForeignKey(typeof(UnitDB))]
        public int UnitID { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Percentage { get; set; }
        public string ReleaseDate { get; set; }
        public string DueDate { get; set; }
        public bool Graded { get; set; }
        public string GradedDate { get; set; }
        public string Grade { get; set; }
        public Assesment ConvertToModel()
        {
            int percent = Int32.Parse(Percentage.Trim('%'));
            Assesment returnValue = new Assesment(this.Code, this.Title, percent, this.ReleaseDate, this.DueDate, this.Graded, this.GradedDate, this.Grade);
            returnValue.AssesmentID = this.AssesmentID;
            returnValue.UnitID = this.UnitID;
            return returnValue;
        }
    }
}
