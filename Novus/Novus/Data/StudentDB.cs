using Novus.Models;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<UnitDB> CurrentUnits { get; set; }

        public Student ConvertToModel()
        {
            ObservableCollection<Semester> enrollment = new ObservableCollection<Semester>();
            try
            {
                foreach (SemesterDB value in Enrollment)
                {
                    enrollment.Add(value.ConvertToModel());
                }
            } catch { }
            
            ObservableCollection<Events> events = new ObservableCollection<Events>();
            try
            {
                foreach (EventsDB value in Events)
                {
                    events.Add(value.ConvertToModel());
                }
            } catch { }

            ObservableCollection<Unit> currentUnits = new ObservableCollection<Unit>();
            try
            {
                foreach (UnitDB value in CurrentUnits)
                {
                    currentUnits.Add(value.ConvertToModel());
                }
            } catch { }


            Student returnValue = new Student(Name, enrollment);
            returnValue.Events = events;
            returnValue.StudentID = StudentID;
            returnValue.CurrentUnits = currentUnits;
            return returnValue;
        }
    }
}
