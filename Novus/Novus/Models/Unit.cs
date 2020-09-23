using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Novus.Models
{
    class Unit
    {
        public bool IsVisible { get; set; }
        public int[] Semester { get; set; }
        public string Code { get; private set; }
        public string Name {get; private set;}

        public Information Information { get; private set; }
        public string FullName { get; private set; }
        public Class[] Lectures { get; set; }
        public Class[] Tutorials { get; set; }
        public Unit(string Code, string Name, Information Information)

        {
            this.Code = Code;
            this.Name = Name;
            this.Information = Information;
            this.IsVisible = false;
            GenerateFullName();
        }

        private void GenerateFullName()
        {
            this.FullName = Code + ' ' + Name;
        }

        public static Unit[] GenerateUnits(int counter)
        {
            Information BlankInformation = new Information(new string[] { "THIS IS INFORMATION THAT AT SOME POINT IN THE FUTURE WILL BE REPLACED WITH REAL STUFF", "THIS IS INFORMATION THAT AT SOME POINT IN THE FUTURE WILL BE REPLACED WITH REAL STUFF" });

            Unit[] Units = new Unit[4];
            for (int i = 0; i < 4; i++)
            {
                Unit unit = new Unit("IFB101", "Test Subject", BlankInformation);
                unit.Lectures = (Class.GenerateClassLecture(2));
                unit.Tutorials = (Class.GenerateClassLecture(4));
                unit.Semester = new int[] { counter, i };

                Units[i] = unit;
            }

            return Units;
        }
    }
}
