﻿using MvvmHelpers.Commands;
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
        public ObservableCollection<string> Information { get; private set; }
        public ObservableCollection<Class> Classes { get; set; }
        public string Colour { get; set; }
        public ObservableCollection<Announcement> StaffAnnouncements { get; set; }
        public ObservableCollection<Assesment> Assesments { get; set; }
        public ObservableCollection<Resources> UnitResources { get; set; }
      
        public Unit(string Code, string Name, ObservableCollection<string> Information, string Colour, ObservableCollection<Announcement> Announcenment, ObservableCollection<Assesment> Assesment)
        {
            this.Code = Code;
            this.Name = Name;
            this.Colour = Colour;
            this.Information = Information;
            this.IsVisible = false;
            this.Classes = new ObservableCollection<Class>();
            this.StaffAnnouncements = Announcenment;
            this.Assesments = Assesment;
            this.UnitResources = new ObservableCollection<Resources>();
            GenerateFullName();
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
            foreach (Class value in Classes)
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

            foreach (string value in Information)
            {
                information += value + "|";
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
                this.Classes.Add(value);
            }
        }

        public void UpdateClassPlanned(bool value, int classID)
        {
            foreach(Class classs in Classes)
            {
                if(classs.ClassID == classID)
                {
                    Classes[Classes.IndexOf(classs)].Planned = value;
                }
            }
        }

        public void UpdateClassRegistered(bool value, int classID)
        {
            foreach (Class classs in Classes)
            {
                if (classs.ClassID == classID)
                {
                    Classes[Classes.IndexOf(classs)].Registerd = value;
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
