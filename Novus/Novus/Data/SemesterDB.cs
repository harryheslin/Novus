using Novus.Models;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novus.Data
{
    public class SemesterDB
    {
        [PrimaryKey, AutoIncrement]
        public int SemesterID { get; set; }

        [ForeignKey(typeof(StudentDB))]
        public int StudentID { get; set; }
        public int SemesterYear { get; set; }
        public int SemesterOfYear { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<UnitDB> EnrolledUnits { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<ClassDB> EnrolledClasses { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<ClassDB> PlannedClasses { get; set; }

        public Semester ConvertToModel()
        {
            List<Unit> enrolledUnits = new List<Unit>();
            try
            {
                foreach (UnitDB value in EnrolledUnits)
                {
                    enrolledUnits.Add(value.ConvertToModel());
                }
            } catch { }

            List<Class> enrolledClasses = new List<Class>();
            try
            {
                foreach (ClassDB value in EnrolledClasses)
                {
                    enrolledClasses.Add(value.ConvertToModel());
                }
            } catch { }

            

            List<Class> plannedClasses = new List<Class>();
            try
            {
                foreach (ClassDB value in PlannedClasses)
                {
                    plannedClasses.Add(value.ConvertToModel());
                }
            } catch { }
            

            Semester returnValue = new Semester(new List<int> { SemesterOfYear, SemesterYear }, enrolledUnits);
            returnValue.SemesterID = SemesterID;
            returnValue.StudentID = StudentID;
            returnValue.EnrolledClasses = enrolledClasses;
            returnValue.PlannedClasses = plannedClasses;
            return returnValue;
        }
    }
}
