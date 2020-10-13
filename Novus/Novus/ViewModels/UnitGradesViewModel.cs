using MvvmHelpers;
using Novus.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Novus.ViewModels
{
    [QueryProperty("Unit", "unit")]
    class UnitGradesViewModel : BaseViewModel
    {
        static Student Student = Student.GenerateStudent(4);

        static public Unit currentUnit = Student.Enrollment[0].EnrolledUnits[0];

        public string GetUnitNumber(string routeCode)
        {
            switch (routeCode)
            {
                case "/unit1":
                    currentUnit = Student.Enrollment[0].EnrolledUnits[0];
                    return currentUnit.FullName;
                case "/IMPL_unit2/unit2":
                    currentUnit = Student.Enrollment[0].EnrolledUnits[1];
                    return currentUnit.FullName;
                case "/IMPL_unit3/unit3":
                    currentUnit = Student.Enrollment[0].EnrolledUnits[2];
                    return currentUnit.FullName;
                case "/IMPL_unit4/unit4":
                    currentUnit = Student.Enrollment[0].EnrolledUnits[3];
                    return currentUnit.FullName;
                default:
                    return "Error";
            }
        }

        string unit;
        public string Unit
        {
            get => unit;
            set
            {
                SetProperty(ref unit, GetUnitNumber(Uri.UnescapeDataString(value)));
                OnPropertyChanged(nameof(GradedAssesment));
                OnPropertyChanged(nameof(Colour));
            }
        }

        string colour;
        public string Colour
        {
            get => currentUnit.Colour;
            set
            {
                SetProperty(ref colour, currentUnit.Colour);
                OnPropertyChanged();
            }
        }

        Assesment[] gradedAssesment;
        public Assesment[] GradedAssesment
        {
            get => currentUnit.GradedAssesments;
            set
            {
                SetProperty(ref gradedAssesment, currentUnit.GradedAssesments);
                OnPropertyChanged();
            }
        }
    }
}
