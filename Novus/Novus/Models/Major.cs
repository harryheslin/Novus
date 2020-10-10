﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Novus.Models
{
    class Major
    {
        private static int majorID = 0;
        public int MajorID { get; private set; }
        public List<string> Information { get; private set; }
        public List<Unit> Units { get; private set; }
        public string Name { get; private set; }
        public bool IsVisible { get; set; }

        public Major(List<string> information, List<Unit> units, string name)
        {
            this.Information = information;
            this.Units = units;
            this.Name = name;
            this.IsVisible = false;
        }

        public static List<Major> GenerateMajors(int number)
        {
            List<Major> Majors = new List<Major>();
            for(int i = 0; i < number; i++)
            {
                Majors.Add(GenerateMajor());
            }
            return Majors;
        }

        public static Major GenerateMajor()
        {
            List<string> BlankInformation = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                BlankInformation.Add("THIS IS INFORMATION THAT WILL BE CHANGED");
            }

            return new Major(BlankInformation, Unit.GenerateUnits(4), "Test Major");
        }

        public static int GenerateMajorID()
        {
            majorID--;
            return majorID;
        }
    }
}
