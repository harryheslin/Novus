using Novus.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Novus.Models
{
    public class NewUnit
    {
        public static ObservableCollection<Unit> AvalibleUnits { get; private set; }
        public static int SemesterID 
        {
            get => SemesterID;
            set
            {
                for(int i = 0; i < AvalibleUnits.Count; i++)
                {
                    AvalibleUnits[i].SemesterID = value;
                }
            }
        }

        public static void AddUnit(Unit unit)
        {
            try
            {
                AvalibleUnits.Add(unit);
            }
            catch
            {
                AvalibleUnits = new ObservableCollection<Unit>();
                AvalibleUnits.Add(unit);
            }
        }

        public static void RemoveUnit(Unit unit)
        {
            try
            {
                AvalibleUnits.Remove(unit);
            }
            catch
            {
                AvalibleUnits = new ObservableCollection<Unit>();
                AvalibleUnits.Remove(unit);
            }
        }

        public static void RemoveAllUnits()
        {
            AvalibleUnits = new ObservableCollection<Unit>();
        }
    }
}
