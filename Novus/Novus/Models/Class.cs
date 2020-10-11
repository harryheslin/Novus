using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Novus.Data;
using SQLite;
using SQLiteNetExtensions.Attributes;

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
        public int ClassID { get; set; }
        public int UnitID { get; set; }
        public int SemesterID { get; set; }
        public ClassType Type { get; private set; }
        public DayOfWeek DayOfWeek { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public string DisplayTime { get; private set; }
        public ClassMode Mode { get; private set; }
        public string DisplayMode { get; private set; }
        public string Room { get; private set; }
        public bool Registerd { get; set; }
        public bool Planned { get; set; }
        public string Tag { get; private set; }

        public Class(ClassType type, DayOfWeek dayOfWeek,DateTime startTime, DateTime endTime, ClassMode mode, string room)
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
            ClassID = -1;
        }

        public ClassDB ConvertToDB()
        {
            ClassDB returnValue = new ClassDB
            {
                ClassID = this.ClassID,
                UnitID = this.UnitID,
                SemesterID = this.SemesterID,
                Type = this.Type,
                DayOfWeek = this.DayOfWeek,
                StartTime = this.StartTime,
                EndTime = this.EndTime,
                DisplayMode = this.DisplayMode,
                Mode = this.Mode,
                DisplayTime = this.DisplayTime,
                Room = this.Room,
                Registerd = this.Registerd,
                Planned = this.Planned,
                Tag = this.Tag
            };

            return returnValue;
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

        public static ObservableCollection<Class> GenerateClassLecture(int returnArrayLength)
        {
            ObservableCollection<Class> returnArray = new ObservableCollection<Class>();
            for (int i = 0; i < returnArrayLength; i++) {
                returnArray.Add(new Class(ClassType.Lecture, DayOfWeek.Monday, DateTime.Now, DateTime.Now, ClassMode.Virtual, "Z501"));
            }
            return returnArray;
        }

        public static ObservableCollection<Class> GenerateClassTutorial( int returnArrayLength)
        {
            ObservableCollection<Class> returnArray = new ObservableCollection<Class>();
            for (int i = 0; i < returnArrayLength; i++)
            {
                returnArray.Add(new Class(ClassType.Tutorial, DayOfWeek.Monday, DateTime.Now, DateTime.Now, ClassMode.Virtual, "Z501"));
            }
            return returnArray;
        }

        public static int GetClassIndex(List<Class> classes, Class indexingClass)
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

        public static int GetClassIndex(List<Class> classes, int indexingClassID)
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
