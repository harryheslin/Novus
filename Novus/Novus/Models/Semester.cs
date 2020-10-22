using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Novus.Data;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Novus.Models
{
    public class Semester
    {
        public int SemesterID { get; private set; }
        public int StudentID { get; set; }
        public ObservableCollection<int> SemesterNumber { get; private set; }
        public ObservableCollection<Unit> EnrolledUnits { get; set; }
        public ObservableCollection<AddUnit> AvalibleUnits { get; private set; }
        public string DisplayName { get; private set; }

        public Semester(ObservableCollection<int> Semester, ObservableCollection<Unit> EnrolledUnits)
        {
            this.SemesterNumber = Semester;
            this.DisplayName = GetFullName();
            this.EnrolledUnits = new ObservableCollection<Unit>();
            this.AvalibleUnits = new ObservableCollection<AddUnit>();

            SetupAvailableUnits();

            foreach (Unit unit in EnrolledUnits)
            {
                EnrollInUnit(unit);
            }
        }

        public Semester(int SemesterID, ObservableCollection<int> Semester, ObservableCollection<Unit> EnrolledUnits)
        {
            this.SemesterID = SemesterID;
            this.SemesterNumber = Semester;
            this.DisplayName = GetFullName();
            this.EnrolledUnits = new ObservableCollection<Unit>();
            this.AvalibleUnits = new ObservableCollection<AddUnit>();

            SetupAvailableUnits();

            foreach (Unit unit in EnrolledUnits)
            {
                EnrollInUnit(unit);
            }
        }

        public Semester()
        {
            SemesterID = -1;
        }

        public SemesterDB ConvertToDB()
        {
            List<UnitDB> enrolledUnits = new List<UnitDB>();
            foreach (Unit value in EnrolledUnits)
            {
                enrolledUnits.Add(value.ConvertToDB());
            }

            SemesterDB returnValue = new SemesterDB
            {
                SemesterID = this.SemesterID,
                StudentID = this.StudentID,
                SemesterYear = this.SemesterNumber[1],
                SemesterOfYear = this.SemesterNumber[0],
                EnrolledUnits = enrolledUnits,
            };

            return returnValue;
        }

        private void SetupAvailableUnits()
        {
            for(int i = 0; i < 4; i++)
            {
                AvalibleUnits.Add(new AddUnit(this.SemesterID));
            }
        }

        private string GetFullName()
        {
            return String.Format("Year {0} Semester {1}", this.SemesterNumber[1] + 1, this.SemesterNumber[0] + 1);
        }

        public void EnrollInUnit(Unit unit)
        {
            if(AvalibleUnits.Count > 0)
            {
                EnrolledUnits.Add(unit);
                AvalibleUnits.RemoveAt(0);
                NewUnit.RemoveUnit(unit);
            }
        }

        public void UnEnrollInUnit(Unit unit)
        {
            int unitIndex = Unit.GetUnitIndex(EnrolledUnits, unit);
            if(unitIndex != -1)
            {
                EnrolledUnits.Remove(unit);
                AvalibleUnits.Add(new AddUnit(this.SemesterID));

                NewUnit.AddUnit(unit);
            }
        }

        public static int[] GetUnitIndex(ObservableCollection<Semester> Enrollment, Unit indexingUnit)
        {
            foreach(Semester semester in Enrollment)
            {
                int unitIndex = Unit.GetUnitIndex(semester.EnrolledUnits, indexingUnit);
                if(unitIndex != -1)
                {
                    return new int[] { Enrollment.IndexOf(semester), unitIndex};
                }
            }

            return new int[]{-1, -1};
        }

        public static int[] GetUnitIndex(ObservableCollection<Semester> Enrollment, int indexingUnitID)
        {
            foreach (Semester semester in Enrollment)
            {
                int unitIndex = Unit.GetUnitIndex(semester.EnrolledUnits, indexingUnitID);
                if (unitIndex != -1)
                {
                    return new int[] { Enrollment.IndexOf(semester), unitIndex };
                }
            }

            return new int[] { -1, -1 };
        }

        public static int GetSemesterIndex(ObservableCollection<Semester> Enrollment, Semester indexingSemester)
        {
            foreach (Semester semester in Enrollment)
            {
                if (semester.SemesterNumber == indexingSemester.SemesterNumber)
                {
                    return Enrollment.IndexOf(semester);
                }
            }

            return -1;
        }

        public static int GetSemesterIndex(ObservableCollection<Semester> Enrollment, ObservableCollection<int> indexingSemesterNumber)
        {
            foreach (Semester semester in Enrollment)
            {
                if (semester.SemesterNumber.Equals(indexingSemesterNumber))
                {
                    return Enrollment.IndexOf(semester);
                }
            }

            return -1;
        }
    }
}
