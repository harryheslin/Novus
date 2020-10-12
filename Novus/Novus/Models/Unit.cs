using MvvmHelpers.Commands;
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
        public ObservableCollection<Class> Classes { get; private set; }
        public string Colour { get; private set; }
        public Announcement[] StaffAnnouncements { get; set; }
        public Assesment[] Assesments { get; set; }
        public Assesment[] GradedAssesments { get; set; }
        public ObservableCollection<Resources> UnitResources { get; set; }

        private static string[] ColourCodes = { "#80EE8B", "#F3B15B", "#A1F1F4", "#EFE379" };
      
        public Unit(string Code, string Name, ObservableCollection<Information> Information, int UnitID)
        {
            this.Code = Code;
            this.Name = Name;
            this.Information = Information;
            this.IsVisible = false;
            this.UnitID = UnitID;
            this.Classes = new ObservableCollection<Class>();
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
            unit.AddClasses(Class.GenerateClassLecture(2, unit.UnitID));
            unit.AddClasses(Class.GenerateClassTutorial(4, unit.UnitID));
            unit.StaffAnnouncements = (Announcement.GenerateAnnouncements("IFB101" , 3));
            unit.Assesments = (Assesment.GenerateAssesments("IFB101", 2));
            unit.GradedAssesments = (Assesment.GenerateCompleteAssesment("IFB101", 1));
            unit.UnitResources = (Resources.GenerateResources());
            return unit;
        }

        public static int GenerateUnitID()
        {
            unitID++;
            return unitID;
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
