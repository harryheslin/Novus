using MvvmHelpers;
using Novus.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Novus.ViewModels
{
    [QueryProperty("Unit", "unit")]
    [QueryProperty("Colour", "colour")]
    [QueryProperty("Announcement", "announcement")]
    class UnitResourcesViewModel : BaseViewModel
    {
        Student TestStudent = Student.GenerateStudent();

        Unit currentUnit;

        public UnitResourcesViewModel()
        {

        }
        public string GetQueryParamDetails(string routeCode, string type)
        {
            switch (routeCode)
            {
                case "/unit1":
                    currentUnit = TestStudent.Enrollment[0].Units[0];
                    return type == "name" ? currentUnit.FullName : currentUnit.Colour;
                case "/IMPL_unit2/unit2":
                    currentUnit = TestStudent.Enrollment[0].Units[1];
                    return type == "name" ? currentUnit.FullName : currentUnit.Colour;
                case "/IMPL_unit3/unit3":
                    currentUnit = TestStudent.Enrollment[0].Units[2];
                    return type == "name" ? currentUnit.FullName : currentUnit.Colour;
                case "/IMPL_unit4/unit4":
                    currentUnit = TestStudent.Enrollment[0].Units[3];
                    return type == "name" ? currentUnit.FullName : currentUnit.Colour;
                default:
                    return "Error";
            }
        }

        public string GetAnnouncements(string routeCode)
        {
            switch (routeCode)
            {
                case "/unit1":
                    currentUnit = TestStudent.Enrollment[0].Units[0];
                    return currentUnit.StaffAnnouncements[0].Title;
                case "/IMPL_unit2/unit2":
                    currentUnit = TestStudent.Enrollment[0].Units[1];
                    return currentUnit.StaffAnnouncements[0].Title;
                case "/IMPL_unit3/unit3":
                    currentUnit = TestStudent.Enrollment[0].Units[2];
                    return currentUnit.StaffAnnouncements[0].Title;
                case "/IMPL_unit4/unit4":
                    currentUnit = TestStudent.Enrollment[0].Units[3];
                    return currentUnit.StaffAnnouncements[0].Title;
                default:
                    return "error";
            }
        }

        string unit;
        public string Unit
        {
            get => unit;
            set
            {
                SetProperty(ref unit, GetQueryParamDetails(Uri.UnescapeDataString(value), "name"));
                OnPropertyChanged();
            }
        }

        string colour;
        public string Colour
        {
            get => colour;
                set
                {
                    SetProperty(ref colour, GetQueryParamDetails(Uri.UnescapeDataString(value), "colour"));
                    OnPropertyChanged();
                }
        }

        string announcement;
        public string Announcement
        {
            get => announcement;
            set
            {
                SetProperty(ref announcement, GetAnnouncements(Uri.UnescapeDataString(value)));
                OnPropertyChanged();
            }
        }
    }
}
