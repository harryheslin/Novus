using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Novus.Models
{
    public class Semester
    {
        [PrimaryKey, AutoIncrement]
        public int SemesterID { get; set; }

        public List<int> SemesterNumber { get; private set; }

        public int SemesterYear {
            set
            {
                SemesterNumber[0] = value;
            }
        }

        public int SemesterOfYear {
            set 
            {
                SemesterNumber[1] = value;
            } 
        }

        [OneToMany]
        public List<Unit> EnrolledUnits { get; set; }

        public int AvalibleUnitsCount { get; set; }

        public List<int> AvalibleUnits { get; private set; }

        [OneToMany]
        public List<Class> EnrolledClasses { get; set; }

        [OneToMany]
        public List<Class> PlannedClasses { get; set; }
        public string DisplayName { get; set; }

        [ForeignKey(typeof(Student))]
        public int StudentID { get; set; }

        public Semester(List<int> Semester, List<Unit> EnrolledUnits)
        {
            this.SemesterNumber = Semester;
            this.SemesterYear = Semester[0];
            this.SemesterOfYear = Semester[0];
            this.DisplayName = GetFullName();
            this.EnrolledUnits = new List<Unit>();
            this.AvalibleUnits = new List<int>(new int[] { 1, 1, 1, 1 });
            this.AvalibleUnitsCount = 4;
            this.EnrolledClasses = new List<Class>();
            this.PlannedClasses = new List<Class>();

            foreach (Unit unit in EnrolledUnits)
            {
                EnrollInUnit(unit);
            }
        }

        public Semester()
        {
            this.SemesterNumber = new List<int>{ -1, -1 };
        }

        public void EnrollInUnit(Unit unit)
        {
            if(AvalibleUnits.Count > 0)
            {
                EnrolledUnits.Add(unit);
                AvalibleUnits.RemoveAt(0);
                AvalibleUnitsCount--;
            }
        }

        public void UnEnrollInUnit(Unit unit)
        {
            int unitIndex = Unit.GetUnitIndex(EnrolledUnits, unit);
            if(unitIndex != -1)
            {
                EnrolledUnits.Remove(unit);
                AvalibleUnits.Add(1);
                AvalibleUnitsCount++;

                foreach(Class oldClass in unit.Classes)
                {
                    UnEnrollInClass(oldClass);
                    UnPlanClass(oldClass);
                }
            }
        }

        public void EnrollInClass(Class newClass)
        {
            int classIndex = Class.GetClassIndex(EnrolledClasses, newClass);
            int unitIndex = Unit.GetUnitIndex(EnrolledUnits, newClass.UnitID);
            if (classIndex == -1 && unitIndex != -1)
            {
                foreach(Class currentClasses in EnrolledClasses)
                {
                    if(currentClasses.Type == newClass.Type && currentClasses.UnitID == newClass.UnitID)
                    {
                        UnEnrollInClass(currentClasses);
                        break;
                    }
                }

                EnrolledClasses.Add(newClass);
            }
        }

        public void UnEnrollInClass(Class oldClass)
        {
            int classIndex = Class.GetClassIndex(EnrolledClasses, oldClass);
            if(classIndex != -1)
            {
                int unitIndex = Unit.GetUnitIndex(EnrolledUnits, oldClass.UnitID);
                EnrolledUnits[unitIndex].UpdateClassRegistered(false, oldClass.ClassID);

                EnrolledClasses.RemoveAt(classIndex);
            }
        }

        public void PlanClass(Class newClass)
        {
            int classIndex = Class.GetClassIndex(EnrolledClasses, newClass);
            if(classIndex == -1)
            {
                PlannedClasses.Add(newClass);
            }
        }

        public void UnPlanClass(Class oldClass)
        {
            int classIndex = Class.GetClassIndex(EnrolledClasses, oldClass);
            if (classIndex != -1)
            {
                EnrolledClasses.RemoveAt(classIndex);
            }
        }

        public static int[] GetUnitIndex(List<Semester> Enrollment, Unit indexingUnit)
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

        public static int[] GetUnitIndex(List<Semester> Enrollment, int indexingUnitID)
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

        public static int GetSemesterIndex(List<Semester> Enrollment, Semester indexingSemester)
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

        public static int GetSemesterIndex(List<Semester> Enrollment, List<int> indexingSemesterNumber)
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

        private string GetFullName()
        {
            return String.Format("Year {0} Semester {1}", this.SemesterNumber[1]+1, this.SemesterNumber[0]+1);
        }
    }
}
