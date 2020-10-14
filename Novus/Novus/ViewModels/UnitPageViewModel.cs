using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Essentials;
using MvvmHelpers;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Novus.Models;
using System.Linq;

namespace Novus.ViewModels
{
    class UnitPageViewModel : BaseViewModel
    {
        static Student Student = App.Student;

        public Command ResourcesPageButton { get; }
        public Command AnnouncementsPageButton { get; }
        public Command GradesPageButton { get; }
        public Command AssesmentPageButton { get; }
        public Command OnedriveButton { get;  }
        public Command TeamsButton { get; }
        public Command TrelloButton { get; }

        public UnitPageViewModel()
        {
            ResourcesPageButton = new Command(GoToResourcesPage);
            AnnouncementsPageButton = new Command(GoToAnnouncementsPage);
            GradesPageButton = new Command(GoToGradesPage);
            AssesmentPageButton = new Command(GoToAssesmentPage);
            OnedriveButton = new Command(GoToOnedrive);
            TeamsButton = new Command(GoToTeams);
            TrelloButton = new Command(GoToTrello);
        }



        static string GetColour()
        {
            int unitNumber = Int32.Parse(GetUnit());
            return Student.CurrentUnits[unitNumber].Colour;
        }

        string unit = Shell.Current.CurrentItem.Title.ToString();

        public string Unit
        {
            get => unit;
            set
            {
                SetProperty(ref unit, value);
                OnPropertyChanged(nameof(unit));
            }
        }

        string colour = GetColour();
        public string Colour
        {
            get => colour;
            set
            {
                SetProperty(ref colour, GetColour());
                OnPropertyChanged();
            }
        }

        static string GetUnit()
        {
            string route = Shell.Current.CurrentState.Location.ToString();
            int routeIndex = Int32.Parse(route.Last().ToString());
            string result = (routeIndex - 1).ToString();
            return result;
        }

        string RouteCode = GetUnit();
        async void GoToResourcesPage()
        {
            await Shell.Current.GoToAsync($"resources?unit={RouteCode}");
        }

        async void GoToAnnouncementsPage()
        {
            await Shell.Current.GoToAsync($"announcements?unit={RouteCode}");
        }

        async void GoToGradesPage()
        {
            await Shell.Current.GoToAsync($"grades?unit={RouteCode}");
        }

        async void GoToAssesmentPage()
        {
            await Shell.Current.GoToAsync($"assesment?unit={RouteCode}");
        }

        async void GoToOnedrive()
        {
            string OnedriveDownload = "https://play.google.com/store/apps/details?id=com.microsoft.skydrive";
            await Launcher.OpenAsync(OnedriveDownload);
        }

        async void GoToTeams()
        {
            string TeamsDownload = "https://play.google.com/store/apps/details?id=com.microsoft.teams";
            await Launcher.OpenAsync(TeamsDownload);
        }

        async void GoToTrello()
        {
            string TrelloDownload = "https://play.google.com/store/apps/details?id=com.trello";
            await Launcher.OpenAsync(TrelloDownload);
        }

    }
}
