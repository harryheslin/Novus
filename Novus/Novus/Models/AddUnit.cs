using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Novus.Models
{
    public class AddUnit
    {
        private static int addUnitID = -1;
        public int AddUnitID { get; set; }
        public bool IsVisible { get; set; }
        public bool IsNotVisible { get; set; }
        public int SemesterID { get; set; }
        public ObservableCollection<Unit> AvalibleUnits
        {
            get
            {
                NewUnit.SemesterID = this.SemesterID;
                return NewUnit.AvalibleUnits;
            }
        }

        public AddUnit(int SemesterID)
        {
            IsVisible = false;
            IsNotVisible = true;
            this.SemesterID = SemesterID;

            GenerateID();
        }

        private void GenerateID()
        {
            addUnitID++;
            AddUnitID = addUnitID;
        }

        public void InverseIsVisible()
        {
            IsNotVisible = !IsNotVisible;
            IsVisible = !IsVisible;
        }
    }
}
