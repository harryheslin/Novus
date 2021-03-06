﻿using System;
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
        public bool IsNotVisible { get; set; }

        public Minor(ObservableCollection<string> information, ObservableCollection<Unit> units, string name)
        {
            this.Units = units;
            this.Name = name;
            this.IsVisible = false;
            this.IsNotVisible = true;
            this.Information = new ObservableCollection<Information>();

            foreach(string value in information)
            {
                this.Information.Add(new Information(value));
            }
        }

        public static int GenerateMinorID()
        {
            minorID--;
            return minorID;
        }
    }
}
