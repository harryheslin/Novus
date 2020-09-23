using System;
using System.Collections.Generic;
using System.Text;

namespace Novus.Models
{
    class Semester
    {
        public int YearNumber { get; private set; }

        public int SemesterNumber { get; private set; }
        public Unit[] Units { get; private set; }

        public string DisplayName { get; private set; }

        public Semester(int Year, int Semester, Unit[] Units)
        {
            this.YearNumber = Year;
            this.SemesterNumber = Semester;
            this.Units = Units;
            this.DisplayName = GetFullName();
        }

        private string GetFullName()
        {
            return String.Format("Year {0} Semester {1}", this.YearNumber+1, this.SemesterNumber+1);
        }
    }
}
