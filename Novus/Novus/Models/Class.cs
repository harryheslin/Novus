using System;
using System.Collections.Generic;
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

        public ClassType Type { get; private set; }
        public DayOfWeek DayOfWeek { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public ClassMode Mode { get; private set; }
        public string Room { get; private set; }
        public Class(ClassType type, DayOfWeek dayOfWeek,DateTime startTime, DateTime endTime, ClassMode mode, string room)
        {
            this.Type = type;
            this.DayOfWeek = dayOfWeek;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Room = room;
        }

        public static Class[] GenerateClassLecture(int returnArrayLength)
        {
            Class[] returnArray = new Class[returnArrayLength];
            for(int i = 0; i < returnArrayLength; i++) {
                returnArray[i] = new Class(ClassType.Lecture, DayOfWeek.Monday, DateTime.Now, DateTime.Now, ClassMode.Virtual, "");
            }
            return returnArray;
        }

        public static Class[] GenerateClassTutorial( int returnArrayLength)
        {
            Class[] returnArray = new Class[returnArrayLength];
            for (int i = 0; i < returnArrayLength; i++)
            {
                returnArray[i] = new Class(ClassType.Tutorial, DayOfWeek.Monday, DateTime.Now, DateTime.Now, ClassMode.Virtual, "");
            }
            return returnArray;
        }
    }
}
