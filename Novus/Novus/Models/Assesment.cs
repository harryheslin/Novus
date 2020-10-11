using System;
using System.Collections.Generic;
using System.Text;
using Novus.Data;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Novus.Models
{
    public class Assesment
    {
        public int AssesmentID { get; set; }
        public int UnitID { get; set; }
        public string Code { get; private set; }
        public string Title { get; private set; }
        public string Percentage { get; private set; }
        public string ReleaseDate { get; private set; }
        public string DueDate { get; private set; }
        public bool Graded { get; private set; }
        public string GradedDate { get; private set; }
        public Assesment(string code, string title, int percentage, string releaseDate, string dueDate)
        {
            this.Code = code;
            this.Title = title;
            this.Percentage = percentage.ToString() + "%";
            this.ReleaseDate = releaseDate;
            this.DueDate = dueDate;
        }

        public AssesmentDB ConvertToDB()
        {
            AssesmentDB returnValue = new AssesmentDB
            {
                AssesmentID = this.AssesmentID,
                UnitID = this.UnitID,
                Code = this.Code,
                Title = this.Title,
                Percentage = this.Percentage,
                ReleaseDate = this.ReleaseDate,
                DueDate = this.DueDate,
                Graded = this.Graded,
                GradedDate = this.GradedDate
            };

            return returnValue;
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
