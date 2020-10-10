using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Novus.Models
{
    public class Resources
    {
        [PrimaryKey, AutoIncrement]
        public int ResourceID { get; private set; }

        [ForeignKey(typeof(Unit))]
        public int UnitID { get; set; }

        public string Week { get; private set; }
        public string[] Files { get; private set; }
        public string Lecture { get; private set; }
        public bool IsVisible { get; set; }
        public Resources(string week, string[] files, string lecture)
        {
            this.Week = week;
            this.Files = files;
            this.Lecture = lecture;
            this.IsVisible = false;
        }

        public static ObservableCollection<Resources> GenerateResources()
        {
            ObservableCollection<Resources> returnCollection = new ObservableCollection<Resources>();
            string[] dummyFiles = { "lecture_slides.pp", "tutorial_slides.pp", "worksheet.pdf" };
            for(int i = 1; i < 14; i++)
            {
                returnCollection.Add(new Resources("Week " + i, dummyFiles, "Week " + i + " Lecture"));
            }
            return returnCollection;
        }
    }
}
