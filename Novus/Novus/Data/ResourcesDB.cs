using Novus.Models;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novus.Data
{
    public class ResourcesDB
    {
        [PrimaryKey, AutoIncrement]
        public int ResourceID { get; set; }

        [ForeignKey(typeof(UnitDB))]
        public int UnitID { get; set; }
        public string Week { get; set; }
        public string Files { get; set; }
        public string Lecture { get; set; }

        public Resources ConvertToModel()
        {
            string[] files = Files.Split('|');
            List<string> NewFiles = new List<string>();

            for(int i = 0; i < files.Length-1; i++)
            {
                NewFiles.Add(files[i]);
            }

            Resources returnValue = new Resources(Week, NewFiles, Lecture);
            returnValue.ResourceID = this.ResourceID;
            returnValue.UnitID = this.UnitID;

            return returnValue;
        }
    }
}
