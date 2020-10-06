using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text; 

namespace Novus.Models
{
    class Semester
    {
        public int[] SemesterNumber { get; private set; }

        public ObservableCollection<Unit> EnrolledUnits { get; set; }

        public List<int> AvalibleUnits { get; private set; }

        public ObservableCollection<Class> EnrolledClasses { get; private set; }

        public ObservableCollection<Class> PlannedClasses { get; private set; }

        public string DisplayName { get; private set; }

        public Semester(int[] Semester, ObservableCollection<Unit> EnrolledUnits)
        {
            this.SemesterNumber = Semester;
            this.DisplayName = GetFullName();
            this.EnrolledUnits = new ObservableCollection<Unit>();
            this.AvalibleUnits = new List<int>(new int[] { 1, 1, 1, 1 });
            this.EnrolledClasses = new ObservableCollection<Class>();
            this.PlannedClasses = new ObservableCollection<Class>();

            foreach (Unit unit in EnrolledUnits)
            {
                EnrollInUnit(unit);
            }
        }

        public Semester()
        {
            this.SemesterNumber = new int[] { -1, -1 };
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

        public static int GetSemesterIndex(ObservableCollection<Semester> Enrollment, int[] indexingSemesterNumber)
        {
            foreach (Semester semester in Enrollment)
            {
                if (semester.SemesterNumber == indexingSemesterNumber)
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
