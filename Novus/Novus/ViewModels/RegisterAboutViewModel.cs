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

        public void SetIsVisibleMajor()
        {
            Course newValue = course[0];
            newValue.IsVisibleMajor = !newValue.IsVisibleMajor;
            Course[0] = newValue;
        }

        public void SetIsVisibleMinor()
        {
            Course newValue = course[0];
            newValue.IsVisibleMinor = !newValue.IsVisibleMinor;
            Course[0] = newValue;
        }

        public void SetIsVisibleMajorUnits(int majorID)
        {
            Course newValue = course[0];
            int majorIndex = GetMajorIndex(majorID);
            if (majorIndex != -1)
            {
                newValue.Majors[majorIndex].IsVisible = !newValue.Majors[majorIndex].IsVisible;
                newValue.Majors[majorIndex].IsNotVisible = !newValue.Majors[majorIndex].IsNotVisible;
            }

            Course[0] = newValue;
        }

        public void SetIsVisibleMajorUnit(int unitID)
        {
            Course newValue = course[0];
            int[] unitIndex = GetUnitIndex(unitID);
            if (unitIndex != new int[] { -1, -1 })
            {
                newValue.Majors[unitIndex[0]].Units[unitIndex[1]].IsVisible = !newValue.Majors[unitIndex[0]].Units[unitIndex[1]].IsVisible;
            }

            Course[0] = newValue;
        }

        public int[] GetUnitIndex(int indexingUnitID)
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

        public int[] GetUnitIndex(Unit indexingUnit)
        {
            foreach (Major major in course[0].Majors)
            {
                foreach (Unit unit in major.Units)
                {
                    if (indexingUnit.UnitID == unit.UnitID)
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

        public int GetMajorIndex(Major indexingMajor)
        {
            foreach (Major major in course[0].Majors)
            {
                if (major.MajorID == indexingMajor.MajorID)
                {
                    return course[0].Majors.IndexOf(major);
                }
            }
            return -1;
        }
    }
}
