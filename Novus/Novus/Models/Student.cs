using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Novus.Models
{
    public class Student
    {
        [PrimaryKey, AutoIncrement]
        public int StudentID { get; set; }
        public string Name { get; set; }

        [OneToMany]
        public List<Semester> Enrollment { get; set; }
        
        [OneToMany]
        public List<Events> Events { get; set; }

        public Student(string Name, int StudentID, List<Semester> Enrollment)
        {
            this.Name = Name;
            this.StudentID = StudentID;
            this.Enrollment = Enrollment;
        }

        public Student()
        {
            this.StudentID = -1;
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

            return new Student("Test Student", 1111111, Enrollment);
        }
    }
}
