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
        public List<Semester> Enrollment { get; set; }
        public List<Events> Events { get; set; }

        public Student(string Name, List<Semester> Enrollment)
        {
            this.Name = Name;
            this.Enrollment = Enrollment;
            this.Events = new List<Events>();
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

            StudentDB returnValue = new StudentDB
            {
                StudentID = this.StudentID,
                Name = this.Name,
                Enrollment = enrollment,
                Events = events
            };

            return returnValue;
        }

        public static Student GenerateStudent(int numberOfUnits)
        {
            List<Semester> Enrollment = new List<Semester>();
            for(int x=0; x<3; x++)
            {
                for(int y=0; y<2; y++)
                {
                    Enrollment.Add(new Semester(new List<int> {y, x}, Unit.GenerateUnits(numberOfUnits)));
                }
            }

            return new Student("Test Student", Enrollment);
        }
    }
}
