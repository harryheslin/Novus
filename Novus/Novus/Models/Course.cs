﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SQLite;
using SQLitePCL;

namespace Novus.Models
{
    class Course
    {
        public int CourseID { get; set; }
        public ObservableCollection<Information> GeneralInformation { get; set; }
        public ObservableCollection<Major> Majors { get; set; }
        public ObservableCollection<Minor> Minors { get; set; }
        public bool IsVisibleGeneral { get; set; }
        public bool IsVisibleMajor { get; set; }
        public bool IsVisibleMinor { get; set; }

        public Course(ObservableCollection<Information> generalInformation, ObservableCollection<Major> majors, ObservableCollection<Minor> minors)
        {
            this.GeneralInformation = generalInformation;
            this.Majors = majors;
            this.Minors = minors;
            this.IsVisibleGeneral = false;
        }

        public Course()
        {
            this.CourseID = -1;
        }
    }
}
