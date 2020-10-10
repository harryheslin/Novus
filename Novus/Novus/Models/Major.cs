using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Novus.Models
{
    class Major
    {
        private static int majorID = 0;
        public int MajorID { get; private set; }
        public ObservableCollection<Information> Information { get; private set; }
        public ObservableCollection<Unit> Units { get; private set; }
        public string Name { get; private set; }
        public bool IsVisible { get; set; }
        public bool IsNotVisible { get; set; }

        public Major(ObservableCollection<Information> information, ObservableCollection<Unit> units, string name)
        {
            this.Information = information;
            this.Units = units;
            this.Name = name;
            this.IsVisible = true;
            this.IsNotVisible = false;
            this.MajorID = GenerateMajorID();
        }

        public static ObservableCollection<Major> GenerateMajors(int number)
        {
            ObservableCollection<Major> Majors = new ObservableCollection<Major>();
            for(int i = 0; i < number; i++)
            {
                Majors.Add(GenerateMajor());
            }
            return Majors;
        }

        public static Major GenerateMajor()
        {
            ObservableCollection<Information> BlankInformation = new ObservableCollection<Information>();
            for (int i = 0; i < 4; i++)
            {
                BlankInformation.Add(new Information("THIS IS INFORMATION THAT WILL BE CHANGED"));
            }

            return new Major(BlankInformation, Unit.GenerateUnits(4), "Test Major");
        }

        public static int GenerateMajorID()
        {
            majorID++;
            return majorID;
        }
    }
}
