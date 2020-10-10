﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Novus.Models
{
    public class Announcement
    {
        [PrimaryKey, AutoIncrement]
        public int AnnouncementID { get; set; }

        [ForeignKey(typeof(Unit))]
        public int UnitID { get; set; }

        public string Unit { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public string User { get; set; }

        public Announcement(string unit, string title, string message, DateTime date, string user)
        {
            this.Unit = unit;
            this.Title = title;
            this.Message = message;
            this.Date = date;
            this.User = user;
        }

        public Announcement() {
            this.AnnouncementID = -1;
        }

        public static Announcement[] GenerateAnnouncements(string unitCode, int returnArrayLength)
        {
            Announcement[] returnArray = new Announcement[returnArrayLength];
            string message = "Hello Students, This is a long test announcement to make sure that the list view expands on this assignment, no real information here as this is fake and Harry is just testing stuff, you know how it is sometimes haha, lol :-P";
            for(int i = 0; i< returnArrayLength; i++)
            {
                returnArray[i] = new Announcement(unitCode, unitCode + " Announcement", message, DateTime.Now, "Srikanth Nair");
            }
            return returnArray;
        }

    }
}
