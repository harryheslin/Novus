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
       
        ObservableCollection<Events> CurrentEvents = App.Student.Events;



        Unit announcementUnit = App.Student.CurrentUnits[0];
        public Command OpenMyUnitsPage { get; }
        public Command CalendarPage { get; }
        public Command EmailPage { get; }
        public Command AnnouncementUnitPage { get; }
        public Command CalendarWeekPage { get; }

        public HomepageViewModel()
        {
            OpenMyUnitsPage = new Command(GoToMyUnitsPage);
            CalendarPage = new Command(GoToCalendarPage);
            EmailPage = new Command(GoToEmailPage);
            AnnouncementUnitPage = new Command(GoToAnnouncementUnitPage);
            CalendarWeekPage = new Command(GoToCalendarWeekPage);
            GetLatestAnnouncement();

            GetLatestEvents();
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

        private void GetLatestEvents()
        {

            if (CurrentEvents.Count == 0)
            {
                latestEventName = "No Events";
                latestEventDate = "00/00/0000";
                latestEventDescription = "No Descrpition";
            }
            else
            {
                Events latestEvents = CurrentEvents[0];
                for (int i = 0; i < CurrentEvents.Count; i++)
                {
                    if (CurrentEvents[i].StartDate > latestEvents.StartDate)
                    {
                        latestEvents = CurrentEvents[i];
                    }
                }
                LastestEvent = latestEvents;
                latestEventName = LastestEvent.EventName;
                latestEventDate = LastestEvent.StartDate.ToString("dd/MM/yyyy");
                if (LastestEvent.EventDescription == null)
                {
                    latestEventDescription = "No Descrpition";
                }
                else
                {
                    latestEventDescription = LastestEvent.EventDescription;
                }

            }

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

        Events latestEvent;
        public Events LastestEvent
        {
            get => latestEvent;
            set
            {
                SetProperty(ref latestEvent, value);
                OnPropertyChanged(nameof(LastestEvent));
            }
        }

        string latestEventDate;
        public string LatestEventDate
        {
            get => latestEventDate;
            set
            {
                SetProperty(ref latestEventDate, value);
                OnPropertyChanged(nameof(LatestEventDate));
            }

        }

        string latestEventName;
        public string LatestEventName
        {
            get => latestEventName;
            set
            {
                SetProperty(ref latestEventName, value);
                OnPropertyChanged(nameof(LatestEventName));
            }
        }

        string latestEventDescription;
        public string LatestEventDescription
        {
            get => latestEventDescription;
            set
            {
                SetProperty(ref latestEventDescription, value);
                OnPropertyChanged(nameof(LatestEventDescription));
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

        async void GoToCalendarWeekPage()
        {
            await Shell.Current.GoToAsync("calendarWeek");
        }

        async void GoToEmailPage()
        {
            string EmailPage = "https://play.google.com/store/apps/details?id=com.google.android.gm&hl=en_AU&gl=US";
            await Launcher.OpenAsync(EmailPage);
        }
    }
}
