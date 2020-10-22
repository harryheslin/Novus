using Novus.Models;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public Semester ConvertToModel()
        {
            ObservableCollection<Unit> enrolledUnits = new ObservableCollection<Unit>();
            try
            {
                foreach (UnitDB value in EnrolledUnits)
                {
                    enrolledUnits.Add(value.ConvertToModel());
                }
            } catch { }
            

            Semester returnValue = new Semester(SemesterID, new ObservableCollection<int> { SemesterOfYear, SemesterYear }, enrolledUnits);
            returnValue.StudentID = StudentID;
            return returnValue;
        }
    }
}
