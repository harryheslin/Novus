using Novus.Models;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novus.Data
{
    public class UnitDB
    {
        [PrimaryKey, AutoIncrement]
        public int UnitID { get; set; }

        [ForeignKey(typeof(SemesterDB))]
        public int SemesterID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Information { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<ClassDB> Classes { get; set; }
        public string Colour { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<AnnouncementDB> StaffAnnouncements { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<AssesmentDB> Assesments { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<ResourcesDB> UnitResources { get; set; }

        public Unit ConvertToModel()
        {
            List<Class> classes = new List<Class>();
            foreach(ClassDB value in Classes)
            {
                classes.Add(value.ConvertToModel());
            }

            List<Announcement> announcements = new List<Announcement>();
            try
            {
                foreach (AnnouncementDB value in StaffAnnouncements)
                {
                    announcements.Add(value.ConvertToModel());
                }
            } catch { }
            
            List<Assesment> assesments = new List<Assesment>();
            try
            {
                foreach (AssesmentDB value in Assesments)
                {
                    assesments.Add(value.ConvertToModel());
                }
            } catch { }
           
            List<Resources> resources = new List<Resources>();
            try
            {
                foreach (ResourcesDB value in UnitResources)
                {
                    resources.Add(value.ConvertToModel());
                }
            } catch { }

            string[] information = Information.Split('|');
            List<string> newInformation = new List<string>();

            for (int i = 0; i < information.Length - 1; i++)
            {
                newInformation.Add(information[i]);
            }

            Unit returnUnit = new Unit(Code, Name, newInformation);
            returnUnit.UnitID = UnitID;
            returnUnit.SemesterID = SemesterID;
            returnUnit.Classes = classes;
            returnUnit.StaffAnnouncements = announcements;
            returnUnit.Assesments = assesments;
            returnUnit.UnitResources = resources;

            return returnUnit;
        }
    }
}
