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
        public ObservableCollection<string> Information { get; private set; }
        public ObservableCollection<Unit> Units { get; private set; }
        public string Name { get; private set; }
        public bool IsVisible { get; set; }
        public bool IsNotVisible { get; set; }

        public Major(ObservableCollection<string> information, ObservableCollection<Unit> units, string name)
        {
            this.Information = information;
            this.Units = units;
            this.Name = name;
            this.IsVisible = false;
            this.IsNotVisible = true;
        }

        public static int GenerateMajorID()
        {
            majorID--;
            return majorID;
        }
    }
}
