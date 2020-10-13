using MvvmHelpers;
using Novus.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Novus.ViewModels
{
    [QueryProperty("Unit", "unit")]
    class UnitAnnouncementsViewModel : BaseViewModel
    {
        static Student Student = App.Student;

        static public Unit currentUnit = Student.CurrentUnits[0];

        public string GetUnitNumber(string routeCode)
        {
            switch (routeCode)
            {
                case "/unit1":
                    currentUnit = Student.CurrentUnits[0];
                    return currentUnit.FullName;
                case "/IMPL_unit2/unit2":
                    currentUnit = Student.CurrentUnits[1];
                    return currentUnit.FullName;
                case "/IMPL_unit3/unit3":
                    currentUnit = Student.CurrentUnits[2];
                    return currentUnit.FullName;
                case "/IMPL_unit4/unit4":
                    currentUnit = Student.CurrentUnits[3];
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
                OnPropertyChanged(nameof(Announcements));
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

        ObservableCollection<Announcement> noAnnouncements()
        {
            ObservableCollection<Announcement> emptyAnnouncement = new ObservableCollection<Announcement>();
            emptyAnnouncement.Add(new Announcement("", unit, "Currently no available announcements", new DateTime(2020, 01, 01, 12, 0, 0), "QUT"));
            return emptyAnnouncement;
        }

        ObservableCollection<Announcement> announcements;
        public ObservableCollection<Announcement> Announcements
        {
            get => (currentUnit.StaffAnnouncements).Count == 0 ? noAnnouncements() : currentUnit.StaffAnnouncements;
            set
            {
                SetProperty(ref announcements, currentUnit.StaffAnnouncements);
                OnPropertyChanged();
            }
        }
    }
}
