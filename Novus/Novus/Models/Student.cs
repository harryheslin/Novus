using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Novus.Models
{
    class Student
    {
        public string Name { get; private set; }
        public int StudentID { get; private set; }
        public ObservableCollection<Semester> Enrollment { get; set; }

        public Student(string Name, int StudentID, ObservableCollection<Semester> Enrollment)
        {
            this.Name = Name;
            this.StudentID = StudentID;
            this.Enrollment = Enrollment;
        }

        public static Student GenerateStudent(int numberOfUnits)
        {
            ObservableCollection<Semester> Enrollment = new ObservableCollection<Semester>();
            for(int x=0; x<3; x++)
            {
                for(int y=0; y<2; y++)
                {
                    Enrollment.Add(new Semester(new int[] {y, x}, Unit.GenerateUnits(numberOfUnits)));
                }
            }

            return new Student("Test Student", 1111111, Enrollment);
        }
    }
}
