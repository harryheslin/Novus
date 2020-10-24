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
        public ObservableCollection<string> GeneralInformation { get; set; }
        public ObservableCollection<Major> Majors { get; set; }
        public ObservableCollection<Minor> Minors { get; set; }

        public Course(ObservableCollection<string> generalInformation, ObservableCollection<Major> majors, ObservableCollection<Minor> minors)
        {
            this.GeneralInformation = generalInformation;
            this.Majors = majors;
            this.Minors = minors;
        }

        public Course()
        {
            this.CourseID = -1;
        }
    }
}
