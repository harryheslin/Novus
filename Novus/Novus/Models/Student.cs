using System;
using System.Collections.Generic;
using System.Text;

namespace Novus.Models
{
    class Student
    {
        public string Name { get; private set; }
        public int StudentID { get; private set; }
        public Semester[] Enrollment { get; private set; }

        public Student(string Name, int StudentID, Semester[] Enrollment)
        {
            this.Name = Name;
            this.StudentID = StudentID;
            this.Enrollment = Enrollment;
        }

        public static Student GenerateStudent()
        {
            Semester[] Enrollment = new Semester[6];
            int counter = 0;
            for(int x=0; x<3; x++)
            {
                for(int y=0; y<2; y++)
                {
                    Enrollment[counter] = new Semester(x, y, Unit.GenerateUnits(counter));
                    counter++;
                }
            }

            return new Student("Test Student", 1111111, Enrollment);
        }
    }
}
