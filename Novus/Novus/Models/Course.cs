using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Novus.Models
{
    class Course
    {
        public ObservableCollection<Information> GeneralInformation { get; private set; }
        public bool IsVisibleGeneral { get; set; }
        public bool IsVisibleMajor { get; set; }
        public bool IsVisibleMinor { get; set; }
        public ObservableCollection<Major> Majors { get; private set; }
        public ObservableCollection<Minor> Minors { get; private set; }

        public Course(ObservableCollection<Information> generalInformation, ObservableCollection<Major> majors, ObservableCollection<Minor> minors)
        {
            this.GeneralInformation = generalInformation;
            this.Majors = majors;
            this.Minors = minors;
            this.IsVisibleGeneral = false;
            this.IsVisibleMajor = true;
            this.IsVisibleMinor = false;
        }

        public static ObservableCollection<Course> GenerateCourse()
        {
            ObservableCollection<Information> BlankInformation = new ObservableCollection<Information>();
            for (int i = 0; i < 4; i++)
            {
                BlankInformation.Add(new Information("THIS IS INFORMATION THAT WILL BE CHANGED"));
            }

            ObservableCollection<Course> course = new ObservableCollection<Course>();
            course.Add(new Course(BlankInformation, Major.GenerateMajors(2), Minor.GenerateMinors(4)));
            return course;
        }
    }
}
