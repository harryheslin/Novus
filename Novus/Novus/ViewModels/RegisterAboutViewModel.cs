using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MvvmHelpers;
using Novus.Data;
using Novus.Models;

namespace Novus.ViewModels
{
    class RegisterAboutViewModel : BaseViewModel
    {
        public RegisterAboutViewModel()
        {
            course = Datastore.GetCourse();
        }

        ObservableCollection<Course> course;
        public ObservableCollection<Course> Course
        {
            get => course;
            set
            {
                SetProperty(ref course, value);
                OnPropertyChanged(nameof(Course));
            }
        }

        public void SetIsVisibleGeneral()
        {
            Course newValue = course[0];
            newValue.IsVisibleGeneral = !newValue.IsVisibleGeneral;
            Course[0] = newValue;

        }

        public void SetIsVisibleMinor()
        {
            Course newValue = course[0];
            newValue.IsVisibleMinor = !newValue.IsVisibleMinor;
            Course[0] = newValue;
        }

        public void SetIsVisibleMinorUnits(int minorID)
        {
            Course newValue = course[0];
            int minorIndex = GetMinorIndex(minorID);
            if (minorIndex != -1)
            {
                newValue.Minors[minorIndex].IsVisible = !newValue.Minors[minorIndex].IsVisible;
            }

            Course[0] = newValue;
        }

        public void SetIsVisibleMinorUnit(int unitID)
        {
            Course newValue = course[0];
            int[] unitIndex = GetUnitIndexMinor(unitID);
            if (unitIndex != new int[] { -1, -1 })
            {
                newValue.Minors[unitIndex[0]].Units[unitIndex[1]].IsVisible = !newValue.Minors[unitIndex[0]].Units[unitIndex[1]].IsVisible;
            }

            Course[0] = newValue;
        }

        public int[] GetUnitIndexMinor(int indexingUnitID)
        {
            foreach (Minor minor in course[0].Minors)
            {
                foreach (Unit unit in minor.Units)
                {
                    if (indexingUnitID == unit.UnitID)
                    {
                        return new int[] { course[0].Minors.IndexOf(minor), minor.Units.IndexOf(unit) };
                    }
                }
            }

            return new int[] { -1, -1 };
        }

        public int GetMinorIndex(int indexingMinorID)
        {
            foreach (Minor minor in course[0].Minors)
            {
                if (minor.MinorID == indexingMinorID)
                {
                    return course[0].Minors.IndexOf(minor);
                }
            }
            return -1;
        }

        public void SetIsVisibleMajor()
        {
            Course newValue = course[0];
            newValue.IsVisibleMajor = !newValue.IsVisibleMajor;
            Course[0] = newValue;
        }

        public void SetIsVisibleMajorUnits(int majorID)
        {
            Course newValue = course[0];
            int majorIndex = GetMajorIndex(majorID);
            if (majorIndex != -1)
            {
                newValue.Majors[majorIndex].IsVisible = !newValue.Majors[majorIndex].IsVisible;
            }

            Course[0] = newValue;
        }

        public void SetIsVisibleMajorUnit(int unitID)
        {
            Course newValue = course[0];
            int[] unitIndex = GetUnitIndexMajor(unitID);
            if (unitIndex != new int[] { -1, -1 })
            {
                newValue.Majors[unitIndex[0]].Units[unitIndex[1]].IsVisible = !newValue.Majors[unitIndex[0]].Units[unitIndex[1]].IsVisible;
            }

            Course[0] = newValue;
        }

        public int[] GetUnitIndexMajor(int indexingUnitID)
        {
            foreach (Major major in course[0].Majors)
            {
                foreach (Unit unit in major.Units)
                {
                    if (indexingUnitID == unit.UnitID)
                    {
                        return new int[] { course[0].Majors.IndexOf(major), major.Units.IndexOf(unit) };
                    }
                }
            }

            return new int[] { -1, -1 };
        }

        public int GetMajorIndex(int indexingMajorID)
        {
            foreach (Major major in course[0].Majors)
            {
                if (major.MajorID == indexingMajorID)
                {
                    return course[0].Majors.IndexOf(major);
                }
            }
            return -1;
        }
    }
}
