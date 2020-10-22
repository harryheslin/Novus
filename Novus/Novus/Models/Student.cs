using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Novus.Data;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Novus.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string Name { get; private set; }
        public ObservableCollection<Semester> Enrollment { get; set; }
        public ObservableCollection<Events> Events { get; set; }
        public ObservableCollection<Unit> CurrentUnits { get; set; }

        public Student(string Name, ObservableCollection<Semester> Enrollment)
        {
            this.Name = Name;
            this.Enrollment = Enrollment;
            this.Events = new ObservableCollection<Events>();
        }

        public StudentDB ConvertToDB()
        {
            List<SemesterDB> enrollment = new List<SemesterDB>();
            foreach (Semester value in Enrollment)
            {
                enrollment.Add(value.ConvertToDB());
            }

            List<EventsDB> events = new List<EventsDB>();
            foreach (Events value in Events)
            {
                events.Add(value.ConvertToDB());
            }

            List<UnitDB> currentUnits = new List<UnitDB>();
            foreach (Unit value in CurrentUnits)
            {
                currentUnits.Add(value.ConvertToDB());
            }

            StudentDB returnValue = new StudentDB
            {
                StudentID = this.StudentID,
                Name = this.Name,
                Enrollment = enrollment,
                Events = events,
                CurrentUnits = currentUnits,
            };

            return returnValue;
        }

        public void PlanClass(Class newClass, int unitID)
        {
            int index = Unit.GetUnitIndex(CurrentUnits, unitID);
            if (index != -1)
            {
                if(newClass.Type == ClassType.Lecture)
                {
                    CurrentUnits[index].Lectures = CheckPlan(CurrentUnits[index].Lectures, newClass.ClassID);
                    CurrentUnits[index].Tutorials = CheckPlan(CurrentUnits[index].Tutorials, newClass.ClassID);
                }
            }
        }

        private ObservableCollection<Class> CheckPlan(ObservableCollection<Class> classes, int classID)
        {
            for (int i = 0; i < classes.Count; i++)
            {
                if (classes[i].ClassID == classID)
                {
                    classes[i].Planned = true;
                }
                else
                {
                    classes[i].Planned = false;
                }
            }

            return classes;
        }

        public void EnrollInClass(Class newClass, int unitID)
        {
            int index = Unit.GetUnitIndex(CurrentUnits, unitID);
            if(index != -1)
            {
                if(newClass.Type == ClassType.Lecture)
                {
                    CurrentUnits[index].Lectures = CheckRegister(CurrentUnits[index].Lectures, newClass);
                } 
                else
                {
                    CurrentUnits[index].Tutorials = CheckRegister(CurrentUnits[index].Tutorials, newClass);
                }

                CheckConflict();
            }
        }

        private ObservableCollection<Class> CheckRegister(ObservableCollection<Class> classes, Class value)
        {
            for (int x = 0; x < classes.Count; x++)
            {
                if (classes[x].Registerd && classes[x].ClassID != value.ClassID)
                {
                    classes[x].Registerd = false;
                }
            }

            return classes;
        }

        private void CheckConflict()
        {
            for(int i = 0; i < CurrentUnits.Count; i++)
            {
                CurrentUnits[i].Lectures = CheckConflictClasses(CurrentUnits[i].Lectures);
                CurrentUnits[i].Tutorials = CheckConflictClasses(CurrentUnits[i].Tutorials);
            }
        }

        private ObservableCollection<Class> CheckConflictClasses(ObservableCollection<Class> classes)
        {
            for (int i = 0; i < CurrentUnits.Count; i++)
            {
                classes = CheckBetweenClasses(classes, CurrentUnits[i].Lectures);
                classes = CheckBetweenClasses(classes, CurrentUnits[i].Tutorials);
            }

            return classes;
        }

        private ObservableCollection<Class> CheckBetweenClasses(ObservableCollection<Class> checking, ObservableCollection<Class> reference)
        {
            for(int i = 0; i < checking.Count; i++)
            {
                for(int x = 0; x < reference.Count; x++)
                {
                    if (checking[i].Registerd && reference[x].Registerd && checking[i].ClassID != reference[x].ClassID && CompareClasses(checking[i], reference[x]))
                    {
                        Unit clashingUnit = GetUnit(reference[x].UnitID);
                        if (clashingUnit.UnitID != -1)
                        {
                            checking[i].Colour = "#EFE379";
                            checking[i].ClashMessage = String.Format("Clash with {0} {1}", clashingUnit.Code, reference[x].Type);
                            checking[i].ClashMessageIsVisible = true;
                        }
                    }
                    else
                    {
                        if(checking[i].Registerd && checking[i].Colour != "#EFE379")
                        {
                            checking[i].Colour = "#3EF650";
                            checking[i].ClashMessage = "";
                            checking[i].ClashMessageIsVisible = false;
                        }
                        else if(checking[i].Planned && checking[i].Colour != "#EFE379")
                        {
                            checking[i].Colour = "#4854FF";
                            checking[i].ClashMessage = "";
                            checking[i].ClashMessageIsVisible = false;
                        } 
                        else if (checking[i].Colour != "#EFE379" || !checking[i].Registerd)
                        {
                            checking[i].Colour = "#FFFFFF";
                            checking[i].ClashMessage = "";
                            checking[i].ClashMessageIsVisible = false;
                        }
                    }
                }
            }

            return checking;
        }

        private bool CompareClasses(Class checking, Class reference)
        {
            if(checking.DayOfWeek != reference.DayOfWeek) return false;

            int[] times = ConvertToSeconds(checking, reference);
            if (times[0] < times[3] && times[1] > times[2]) return true;

            return false;
        }

        private int[] ConvertToSeconds(Class checking, Class reference)
        {
            int checkStart = ToSeconds(checking.StartTime.Second, checking.StartTime.Minute, checking.StartTime.Hour);
            int checkEnd = ToSeconds(checking.EndTime.Second, checking.EndTime.Minute, checking.EndTime.Hour);

            int referenceStart = ToSeconds(reference.StartTime.Second, reference.StartTime.Minute, reference.StartTime.Hour);
            int referenceEnd = ToSeconds(reference.EndTime.Second, reference.EndTime.Minute, reference.EndTime.Hour);

            return new int[] { checkStart, checkEnd, referenceStart, referenceEnd };
        }

        private int ToSeconds(int seconds, int minutes, int hours)
        {
            return seconds + (minutes * 60) + (hours * 60 * 60);
        }

        private Unit GetUnit(int unitID)
        {
            int index = Unit.GetUnitIndex(CurrentUnits, unitID);
            if(index != -1)
            {
                return CurrentUnits[index];
            }

            return new Unit();
        }
    }
}
