using Android.Test;
using Java.Lang;
using Java.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novus.Models
{
    class Assesment
    {
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
