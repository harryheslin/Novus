using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text; 

namespace Novus.Models
{
    class Semester
    {
        public int[] SemesterNumber { get; private set; }

        public ObservableCollection<Unit> EnrolledUnits { get; private set; }

        public List<int> AvalibleUnits { get; private set; }

        public string DisplayName { get; private set; }

        public Semester(int[] Semester, ObservableCollection<Unit> EnrolledUnits)
        {
            this.SemesterNumber = Semester;
            this.DisplayName = GetFullName();
            this.EnrolledUnits = new ObservableCollection<Unit>();
            this.AvalibleUnits = new List<int>(new int[] { 1, 1, 1, 1 });

            foreach (Unit unit in EnrolledUnits)
            {
                EnrollInUnit(unit);
            }
        }

        public void EnrollInUnit(Unit unit)
        {
            if(AvalibleUnits.Count > 0)
            {
                EnrolledUnits.Add(unit);
                AvalibleUnits.RemoveAt(0);
            }
        }

        public void UnEnrollInUnit(Unit unit)
        {
            foreach(Unit value in EnrolledUnits)
            {
                if(value.UnitID == unit.UnitID)
                {
                    EnrolledUnits.Remove(unit);
                    AvalibleUnits.Add(1);
                    return;
                }
            }
        }

        private string GetFullName()
        {
            return String.Format("Year {0} Semester {1}", this.SemesterNumber[1]+1, this.SemesterNumber[0]+1);
        }
    }
}
