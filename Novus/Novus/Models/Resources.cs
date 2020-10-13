using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Novus.Data;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Novus.Models
{
    public class Resources
    {
        public int ResourceID { get; set; }
        public int UnitID { get; set; }
        public string Week { get; private set; }
        public List<string> Files { get; private set; }
        public string Lecture { get; private set; }
        public bool IsVisible { get; set; }
        public Resources(string week, List<string> files, string lecture)
        {
            this.Week = week;
            this.Files = files;
            this.Lecture = lecture;
            this.IsVisible = false;
        }

        public ResourcesDB ConvertToDB()
        {
            string files = "";

            foreach(string file in Files)
            {
                files += file + "|";
            }

            ResourcesDB returnValue = new ResourcesDB
            {
                ResourceID = this.ResourceID,
                UnitID = this.UnitID,
                Week = this.Week,
                Files = files,
                Lecture = this.Lecture
            };

            return returnValue;
        }

        public static ObservableCollection<Resources> GenerateResources()
        {
            ObservableCollection<Resources> returnCollection = new ObservableCollection<Resources>();
            List<string> dummyFiles = new List<string> { "lecture_slides.pp", "tutorial_slides.pp", "worksheet.pdf" };
            for(int i = 1; i < 14; i++)
            {
                returnCollection.Add(new Resources("Week " + i, dummyFiles, "Week " + i + " Lecture"));
            }
            return returnCollection;
        }
    }
}
