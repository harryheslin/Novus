using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Telerik.Windows.Documents.Spreadsheet.Expressions.Functions;

namespace Novus.Models
{
    enum ClassType
    {
        Lecture = 1,
        Tutorial = 2,
        Practical = 3
    }
    enum ClassMode
    {
        Physical = 1,
        Virtual = 2
    }

    class Class
    {
        private static int classID = 0;
        public int ClassID { get; private set; }

        public int UnitID { get; private set; }
        public ClassType Type { get; private set; }
        public DayOfWeek DayOfWeek { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public string DisplayTime { get; private set; }
        public ClassMode Mode { get; private set; }
        public string DisplayMode { get; private set; }
        public string Room { get; private set; }
        public bool Registerd { get; set; }
        public string Tag { get; private set; }

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
            this.ClassID = GenerateClassID();
            this.UnitID = UnitID;
            this.Tag = GenerateTag();
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
            for(int i = 0; i < returnArrayLength; i++) {
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

        public static int GenerateClassID()
        {
            classID++;
            return classID;
        }
    }
}
