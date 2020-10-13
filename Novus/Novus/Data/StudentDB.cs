using Novus.Models;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novus.Data
{
    public class StudentDB
    {
        [PrimaryKey, AutoIncrement]
        public int StudentID { get; set; }
        public string Name { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<SemesterDB> Enrollment { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<EventsDB> Events { get; set; }

        public Student ConvertToModel()
        {
            List<Semester> enrollment = new List<Semester>();
            try
            {
                foreach (SemesterDB value in Enrollment)
                {
                    enrollment.Add(value.ConvertToModel());
                }
            } catch { }
            
            List<Events> events = new List<Events>();
            try
            {
                foreach (EventsDB value in Events)
                {
                    events.Add(value.ConvertToModel());
                }
            } catch { }
            
            Student returnValue = new Student(Name, enrollment);
            returnValue.Events = events;
            returnValue.StudentID = StudentID;
            return returnValue;
        }
    }
}
