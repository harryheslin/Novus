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
        public int SemesterID { get; set; }
        public int StudentID { get; set; }
        public ObservableCollection<int> SemesterNumber { get; private set; }
        public ObservableCollection<Unit> EnrolledUnits { get; set; }
        public ObservableCollection<int> AvalibleUnits { get; private set; }
        public ObservableCollection<Class> EnrolledClasses { get; set; }
        public ObservableCollection<Class> PlannedClasses { get; set; }
        public string DisplayName { get; private set; }

        public Semester(ObservableCollection<int> Semester, ObservableCollection<Unit> EnrolledUnits)
        {
            this.SemesterNumber = Semester;
            this.DisplayName = GetFullName();
            this.EnrolledUnits = new ObservableCollection<Unit>();
            this.AvalibleUnits = new ObservableCollection<int>(new int[] { 1, 1, 1, 1 });
            this.EnrolledClasses = new ObservableCollection<Class>();
            this.PlannedClasses = new ObservableCollection<Class>();

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

            List<ClassDB> enrolledClasses = new List<ClassDB>();
            foreach (Class value in EnrolledClasses)
            {
                enrolledClasses.Add(value.ConvertToDB());
            }

            List<ClassDB> plannedClasses = new List<ClassDB>();
            foreach (Class value in PlannedClasses)
            {
                plannedClasses.Add(value.ConvertToDB());
            }

            SemesterDB returnValue = new SemesterDB
            {
                SemesterID = this.SemesterID,
                StudentID = this.StudentID,
                SemesterYear = this.SemesterNumber[1],
                SemesterOfYear = this.SemesterNumber[0],
                EnrolledUnits = enrolledUnits,
                EnrolledClasses = enrolledClasses,
                PlannedClasses = plannedClasses
            };

            return returnValue;
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
            }
        }

        public void UnEnrollInUnit(Unit unit)
        {
            int unitIndex = Unit.GetUnitIndex(EnrolledUnits, unit);
            if(unitIndex != -1)
            {
                EnrolledUnits.Remove(unit);
                AvalibleUnits.Add(1);

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
