﻿using System;
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
        Tutorial = 2
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
        public string Colour { get; set; }
        public string ClashMessage { get; set; }
        public bool ClashMessageIsVisible { get; set; }
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
            this.Colour = "#FFFFFF";
            this.ClashMessage = "";
            this.ClashMessageIsVisible = false;
            GenerateTag();
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
                Colour = this.Colour,
                ClashMessage = this.ClashMessage,
                ClashMessageIsVisible = this.ClashMessageIsVisible
            };

            return returnValue;
        }

        public void GenerateTag()
        {
            this.Tag = String.Format("{0}", ClassID.ToString());
        }

        private string GenerateDisplayTime()
        {
            return StartTime.ToString("HH:mm") + " - " + EndTime.ToString("HH:mm");
        }

        private string GenerateDisplayMode()
        {
            return Enum.GetName(typeof(ClassMode), Mode);
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
