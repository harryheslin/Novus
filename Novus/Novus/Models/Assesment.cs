using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Novus.Models
{
    public class Assesment
    {
        [PrimaryKey, AutoIncrement]
        public int AssesmentID { get; set; }

        [ForeignKey(typeof(Unit))]
        public int UnitID { get; set; }

        public string Code { get; set; }
        public string Title { get; set; }
        public string Percentage { get; set; }
        public string ReleaseDate { get; set; }
        public string DueDate { get; set; }
        public bool Graded { get; set; }
        public string GradedDate { get; set; }
        public Assesment(string code, string title, int percentage, string releaseDate, string dueDate)
        {
            this.Code = code;
            this.Title = title;
            this.Percentage = percentage.ToString() + "%";
            this.ReleaseDate = releaseDate;
            this.DueDate = dueDate;
        }

        public Assesment()
        {
            this.AssesmentID = -1;
        }

        public static Assesment[] GenerateAssesments(string unitCode, int returnArrayLength)
        {
            Assesment[] returnArray = new Assesment[returnArrayLength];
            for(int i = 0; i< returnArrayLength; i++)
            {
                returnArray[i] = new Assesment(unitCode + i.ToString(), unitCode + " Test Assignment", 30, DateTime.MinValue.ToShortDateString(), DateTime.Now.ToShortDateString());
            }
            return returnArray;
        }
    }
}
