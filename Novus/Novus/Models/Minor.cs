using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Novus.Models
{
    class Minor
    {
        private static int minorID = 0;
        public int MinorID { get; private set; }
        public ObservableCollection<Information> Information { get; private set; }
        public ObservableCollection<Unit> Units { get; private set; }
        public string Name { get; private set; }
        public bool IsVisible { get; set; }

        public Minor(ObservableCollection<Information> information, ObservableCollection<Unit> units, string name)
        {
            this.Information = information;
            this.Units = units;
            this.Name = name;
            this.IsVisible = false;
        }

        public static ObservableCollection<Minor> GenerateMinors(int number)
        {
            ObservableCollection<Minor> Minors = new ObservableCollection<Minor>();
            for (int i = 0; i < number; i++)
            {
                Minors.Add(GenerateMinor());
            }
            return Minors;
        }

        public static Minor GenerateMinor()
        {
            ObservableCollection<Information> BlankInformation = new ObservableCollection<Information>();
            for (int i = 0; i < 4; i++)
            {
                BlankInformation.Add(new Information("THIS IS INFORMATION THAT WILL BE CHANGED"));
            }

            return new Minor(BlankInformation, Unit.GenerateUnits(4), "Test Major");
        }

        public static int GenerateMinorID()
        {
            minorID--;
            return minorID;
        }
    }
}
