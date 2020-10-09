using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SQLite;
using SQLitePCL;

namespace Novus.Models
{
    class Course
    {
        [PrimaryKey, AutoIncrement]
        public int CourseID { get; set; }
        public List<Information> GeneralInformation { get; set; }
        public List<Major> Majors { get; set; }
        public List<Minor> Minors { get; set; }

        public Course(List<Information> generalInformation, List<Major> majors, List<Minor> minors)
        {
            this.GeneralInformation = generalInformation;
            this.Majors = majors;
            this.Minors = minors;
        }

        public Course()
        {
            this.CourseID = -1;
        }

        public static List<Course> GenerateCourse()
        {
            List<Information> BlankInformation = new List<Information>();
            for (int i = 0; i < 4; i++)
            {
                BlankInformation.Add(new Information("THIS IS INFORMATION THAT WILL BE CHANGED"));
            }

            List<Course> course = new List<Course>();
            //course.Add(new Course(BlankInformation, Major.GenerateMajors(2), Minor.GenerateMinors(4)));
            return course;
        }
    }
}
