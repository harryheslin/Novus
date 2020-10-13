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
                CurrentUnits = currentUnits
            };

            return returnValue;
        }
    }
}
