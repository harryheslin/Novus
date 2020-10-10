﻿using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Novus.Models
{
    public class Unit
    {
        [PrimaryKey, AutoIncrement]
        public int UnitID { get; private set; }

        [ForeignKey(typeof(Semester))]
        public int SemesterID { get; set; }

        public bool IsVisible { get; set; }
        public string Code { get; private set; }
        public string Name {get; private set;}
        public List<string> Information { get; private set; }
        public string FullName { get; private set; }

        [OneToMany]
        public List<Class> Classes { get; private set; }
        public string Colour { get; private set; }

        [OneToMany]
        public List<Announcement> StaffAnnouncements { get; set; }

        [OneToMany]
        public List<Assesment> Assesments { get; set; }

        [OneToMany]
        public List<Resources> UnitResources { get; set; }

        private static string[] ColourCodes = { "#80EE8B", "#F3B15B", "#A1F1F4", "#EFE379" };
      
        public Unit(string Code, string Name, List<string> Information)
        {
            this.Code = Code;
            this.Name = Name;
            this.Information = Information;
            this.IsVisible = false;
            this.Classes = new List<Class>();
            GenerateFullName();
        }

        public Unit()
        {
            this.UnitID = -1;
        }

        private void GenerateFullName()
        {
            this.FullName = Code + ' ' + Name;
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

        public static List<Unit> GenerateUnits(int number)
        {
            List<Unit> Units = new List<Unit>();
            for (int i = 0; i < number; i++)
            {
                Units.Add(GenerateUnit());
                Units[i].Colour = ColourCodes[i];
            }
            return Units;
        }

        public static Unit GenerateUnit()
        {
            List<string> BlankInformation = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                BlankInformation.Add("THIS IS INFORMATION THAT WILL BE CHANGED");
            }
          
            Unit unit = new Unit("IFB101", "Test Subject", BlankInformation);
            unit.AddClasses(Class.GenerateClassLecture(2, unit.UnitID));
            unit.AddClasses(Class.GenerateClassTutorial(4, unit.UnitID));
            //unit.StaffAnnouncements = (Announcement.GenerateAnnouncements("IFB101" , 3));
            //unit.Assesments = (Assesment.GenerateAssesments("IFB101", 2));
            //unit.UnitResources = (Resources.GenerateResources());
            return unit;
        }

        public static int GetUnitIndex(List<Unit> units, int indexingUnitID)
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

        public static int GetUnitIndex(List<Unit> units, Unit indexingUnit)
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
