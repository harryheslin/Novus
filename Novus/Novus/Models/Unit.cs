using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using SQLite;
using SQLiteNetExtensions.Attributes;
using Novus.Data;

namespace Novus.Models
{
    public class Unit
    {
        public int UnitID { get; set; }
        public int SemesterID { get; set; }
        public int StudentID { get; set; }
        public bool IsVisible { get; set; }
        public string Code { get; private set; }
        public string Name { get; private set; }
        public string FullName { get; set; }
        public ObservableCollection<Information> Information { get; private set; }
        public ObservableCollection<Class> Lectures { get; set; }
        public ObservableCollection<Class> Tutorials { get; set; }
        public string Colour { get; set; }
        public ObservableCollection<Announcement> StaffAnnouncements { get; set; }
        public ObservableCollection<Assesment> Assesments { get; set; }
        public ObservableCollection<Resources> UnitResources { get; set; }
      
        public Unit(string Code, string Name, ObservableCollection<string> Information, string Colour, ObservableCollection<Announcement> Announcenment, ObservableCollection<Assesment> Assesment, ObservableCollection<Resources> Resources)
        {
            this.Code = Code;
            this.Name = Name;
            this.Colour = Colour;
            this.IsVisible = false;
            this.Lectures = new ObservableCollection<Class>();
            this.Tutorials = new ObservableCollection<Class>();
            this.StaffAnnouncements = Announcenment;
            this.Assesments = Assesment;
            this.UnitResources = Resources;
            this.Information = new ObservableCollection<Information>();

            GenerateFullName();

            foreach(string line in Information)
            {
                this.Information.Add(new Information(line));
            }
        }

        public Unit()
        {
            UnitID = -1;
        }

        private void GenerateFullName()
        {
            this.FullName = Code + ' ' + Name;
        }

        public UnitDB ConvertToDB()
        {
            List<ClassDB> classes = new List<ClassDB>();
            foreach (Class value in Tutorials)
            {
                classes.Add(value.ConvertToDB());
            }

            foreach(Class value in Lectures)
            {
                classes.Add(value.ConvertToDB());
            }

            List<AnnouncementDB> announcements = new List<AnnouncementDB>();
            foreach (Announcement value in StaffAnnouncements)
            {
                announcements.Add(value.ConvertToDB());
            }

            List<AssesmentDB> assesments = new List<AssesmentDB>();
            foreach (Assesment value in Assesments)
            {
                assesments.Add(value.ConvertToDB());
            }

            List<ResourcesDB> resources = new List<ResourcesDB>();
            foreach (Resources value in UnitResources)
            {
                resources.Add(value.ConvertToDB());
            }

            string information = "";

            foreach (Information value in Information)
            {
                information += value.Line + "|";
            }

            UnitDB returnValue = new UnitDB
            {
                UnitID = this.UnitID,
                SemesterID = this.SemesterID,
                Code = this.Code,
                Colour = this.Colour,
                Name = this.Name,
                Information = information,
                Classes = classes,
                StaffAnnouncements = announcements,
                Assesments = assesments,
                UnitResources = resources,
                StudentID = this.StudentID
            };

            return returnValue;
        }

        public void AddClasses(ObservableCollection<Class> classes)
        {
            foreach(Class value in classes)
            {
                if(value.Type == ClassType.Lecture)
                {
                    this.Lectures.Add(value);
                } 
                else
                {
                    this.Tutorials.Add(value);
                }
            }
        }

        public static int GetUnitIndex(ObservableCollection<Unit> units, int indexingUnitID)
        {
            foreach (Unit unit in units)
            {
                if (unit.UnitID == indexingUnitID)
                {
                    return units.IndexOf(unit);
                }
            }

            return -1;
        }

        public static int GetUnitIndex(ObservableCollection<Unit> units, Unit indexingUnit)
        {
            foreach(Unit unit in units)
            {
                if(unit.UnitID == indexingUnit.UnitID)
                {
                    return units.IndexOf(unit);
                }
            }

            return -1;
        }        
    }
}
