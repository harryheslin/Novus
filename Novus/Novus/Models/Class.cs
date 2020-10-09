using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SQLite;

namespace Novus.Models
{
    public enum ClassType
    {
        Lecture = 1,
        Tutorial = 2,
        Practical = 3
    }
    public enum ClassMode
    {
        Physical = 1,
        Virtual = 2
    }

    public class Class
    {

        [PrimaryKey, AutoIncrement]
        public int ClassID { get; set; }

        public int UnitID { get; set; }
        public ClassType Type { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string DisplayTime { get; set; }
        public ClassMode Mode { get; set; }
        public string DisplayMode { get; set; }
        public string Room { get; set; }
        public bool Registerd { get; set; }
        public bool Planned { get; set; }
        public string Tag { get; set; }

        public Class(ClassType type, DayOfWeek dayOfWeek,DateTime startTime, DateTime endTime, ClassMode mode, string room, int UnitID)
        {
            this.Type = type;
            this.DayOfWeek = dayOfWeek;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Room = room;
            this.Mode = mode;
            this.DisplayTime = GenerateDisplayTime();
            this.DisplayMode = GenerateDisplayMode();
            this.Registerd = false;
            this.Planned = false;
            this.UnitID = UnitID;
            this.Tag = GenerateTag();
        }

        public Class()
        {
            this.ClassID = -1;
        }

        private string GenerateTag()
        {
            string returnString = String.Format("{0}|{1}", UnitID.ToString(), ClassID.ToString());
            return returnString;
        }

        private string GenerateDisplayTime()
        {
            return StartTime.ToString("HH:mm") + " - " + EndTime.ToString("HH:mm");
        }

        private string GenerateDisplayMode()
        {
            return Enum.GetName(typeof(ClassMode), Mode);
        }

        public static ObservableCollection<Class> GenerateClassLecture(int returnArrayLength, int unitID)
        {
            ObservableCollection<Class> returnArray = new ObservableCollection<Class>();
            for (int i = 0; i < returnArrayLength; i++) {
                returnArray.Add(new Class(ClassType.Lecture, DayOfWeek.Monday, DateTime.Now, DateTime.Now, ClassMode.Virtual, "Z501", unitID));
            }
            return returnArray;
        }

        public static ObservableCollection<Class> GenerateClassTutorial( int returnArrayLength, int unitID)
        {
            ObservableCollection<Class> returnArray = new ObservableCollection<Class>();
            for (int i = 0; i < returnArrayLength; i++)
            {
                returnArray.Add(new Class(ClassType.Tutorial, DayOfWeek.Monday, DateTime.Now, DateTime.Now, ClassMode.Virtual, "Z501", unitID));
            }
            return returnArray;
        }

        public static int GetClassIndex(ObservableCollection<Class> classes, Class indexingClass)
        {
            foreach (Class classs in classes)
            {
                if (classs.ClassID == indexingClass.ClassID)
                {
                    return classes.IndexOf(classs);
                }
            }
            return -1;
        }

        public static int GetClassIndex(ObservableCollection<Class> classes, int indexingClassID)
        {
            foreach (Class classs in classes)
            {
                if (classs.ClassID == indexingClassID)
                {
                    return classes.IndexOf(classs);
                }
            }
            return -1;
        }
    }
}
