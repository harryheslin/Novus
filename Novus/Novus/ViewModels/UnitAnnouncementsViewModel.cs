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
            int route = Int32.Parse(routeCode);
            currentUnit = Student.CurrentUnits[route];
            return currentUnit.FullName;

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

        private ObservableCollection<Announcement> noAnnouncements()
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
