using MvvmHelpers;
using Novus.Models;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Novus.ViewModels
{
    class HomepageViewModel : BaseViewModel
    {
        ObservableCollection<Unit> currentUnits = App.Student.CurrentUnits;

        Unit announcementUnit = App.Student.CurrentUnits[0];
        public Command OpenMyUnitsPage { get; }
        public Command CalendarPage { get; }
        public Command EmailPage { get; }
        public Command AnnouncementUnitPage { get; }

        //define a command for going to the next event
        public Command NextEvent { get; }

        public HomepageViewModel()
        {
            OpenMyUnitsPage = new Command(GoToMyUnitsPage);
            CalendarPage = new Command(GoToCalendarPage);
            EmailPage = new Command(GoToEmailPage);
            AnnouncementUnitPage = new Command(GoToAnnouncementUnitPage);
            NextEvent = new Command(GoToNextEvent);
            GetLatestAnnouncement();
        }

        private void GetLatestAnnouncement()
        {
            Announcement latest = currentUnits[0].StaffAnnouncements[0];
            Unit latestUnit = currentUnits[0];
            for (int i = 0; i < currentUnits.Count; i++)
            {
                for (int k = 0; k < currentUnits[i].StaffAnnouncements.Count; k++)
                {
                    if (currentUnits[i].StaffAnnouncements[k].Date > latest.Date)
                    {

                        latest = currentUnits[i].StaffAnnouncements[k];
                        latestUnit = currentUnits[i];
                    }
                }
            }
            announcementUnit = latestUnit;
            LatestAnnouncement = latest;
        }

        Announcement latestAnnouncement;

        public Announcement LatestAnnouncement
        {
            get => latestAnnouncement;
            set
            {
                SetProperty(ref latestAnnouncement, value);
                OnPropertyChanged(nameof(AnnouncementColour));
            }
        }

        public string LatestAnnouncementDate
        {
            get => latestAnnouncement.Date.ToShortDateString();
        }

        string announcementColour;
        public string AnnouncementColour
        {
            get => announcementUnit.Colour;
            set
            {
                SetProperty(ref announcementColour, value);
            }
        }

        async void GoToAnnouncementUnitPage(object s)
        {
            string param = s.ToString();

            for (int i = 0; i < App.Student.CurrentUnits.Count; i++)
            {
                if (param == App.Student.CurrentUnits[i].Code)
                {
                    string path = "unit?unit=" + i + "&routeCode=" + i;
                    await Shell.Current.GoToAsync($"{path}");
                }
            }
        }
        async void GoToMyUnitsPage()
        {
            await Shell.Current.GoToAsync($"myUnitsPage");
        }

        async void GoToCalendarPage()
        {
            await Shell.Current.GoToAsync($"calendarHome");
        }

        //go to the next event page
        async void GoToNextEvent()
        {
            await Shell.Current.GoToAsync("nextEvent");
        }

        async void GoToEmailPage()
        {
            string EmailPage = "https://play.google.com/store/apps/details?id=com.google.android.gm&hl=en_AU&gl=US";
            await Launcher.OpenAsync(EmailPage);
        }
    }
}
