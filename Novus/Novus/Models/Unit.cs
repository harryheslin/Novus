﻿using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace Novus.Models
{
    class Unit
    {
        private static int unitID = 0; 
        public bool IsVisible { get; set; }
        public int UnitID { get; private set; }
        public string Code { get; private set; }
        public string Name {get; private set;}
        public ObservableCollection<Information> Information { get; private set; }
        public string FullName { get; private set; }
        public ObservableCollection<Class> Lectures { get; set; }
        public ObservableCollection<Class> Tutorials { get; set; }
        public string Colour { get; private set; }
        public Announcement[] StaffAnnouncements { get; set; }
        public Assesment[] Assesments { get; set; }
        public ObservableCollection<Resources> UnitResources { get; set; }

        private static string[] ColourCodes = { "#80EE8B", "#F3B15B", "#A1F1F4", "#EFE379" };
      
        public Unit(string Code, string Name, ObservableCollection<Information> Information, int UnitID)
        {
            this.Code = Code;
            this.Name = Name;
            this.Information = Information;
            this.IsVisible = false;
            this.UnitID = UnitID;
            GenerateFullName();
        }

        private void GenerateFullName()
        {
            this.FullName = Code + ' ' + Name;
        }

        public static ObservableCollection<Unit> GenerateUnits(int number)
        {
            ObservableCollection<Unit> Units = new ObservableCollection<Unit>();
            for (int i = 0; i < number; i++)
            {
                Units.Add(GenerateUnit());
                Units[i].Colour = ColourCodes[i];
            }
            return Units;
        }

        public static Unit GenerateUnit()
        {
            ObservableCollection<Information> BlankInformation = new ObservableCollection<Information>();
            for (int i = 0; i < 4; i++)
            {
                BlankInformation.Add(new Information("THIS IS INFORMATION THAT WILL BE CHANGED"));
            }
          
            Unit unit = new Unit("IFB101", "Test Subject", BlankInformation, Unit.GenerateUnitID());
            unit.Lectures = (Class.GenerateClassLecture(2, unit.UnitID));
            unit.Tutorials = (Class.GenerateClassLecture(4, unit.UnitID));
            unit.StaffAnnouncements = (Announcement.GenerateAnnouncements("IFB101" , 3));
            unit.Assesments = (Assesment.GenerateAssesments("IFB101", 2));
            unit.UnitResources = (Resources.GenerateResources());
            return unit;
        }

        public static int GenerateUnitID()
        {
            unitID++;
            return unitID;
        }
    }
}
