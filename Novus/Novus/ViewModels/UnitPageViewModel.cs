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
    [QueryProperty("Unit", "unit")]
    [QueryProperty("RouteCode", "routeCode")]
    class UnitPageViewModel : BaseViewModel
    {
        static Student Student = App.Student;

        static public Unit currentUnit = Student.CurrentUnits[0];

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

        public string GetUnitNumber(string routeCode)
        {
            int route = Int32.Parse(routeCode);
            currentUnit = Student.CurrentUnits[route];
            return currentUnit.Name;

        }

        string unit;
        public string Unit
        {
            get => unit;
            set
            {
                SetProperty(ref unit, GetUnitNumber(Uri.UnescapeDataString(value)));
                OnPropertyChanged(nameof(Colour));
                OnPropertyChanged(nameof(RouteCode));
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

        string routeCode;

        public string RouteCode 
        {
            get => routeCode;
            set
            {
                SetProperty(ref routeCode, Uri.UnescapeDataString(value));
                OnPropertyChanged(nameof(Unit));
                OnPropertyChanged(nameof(Colour));
            }
        }



        async void GoToResourcesPage()
        {
            await Shell.Current.GoToAsync($"/resources?unit={RouteCode}");
        }

        async void GoToAnnouncementsPage()
        {
            await Shell.Current.GoToAsync($"/announcements?unit={RouteCode}");
        }

        async void GoToGradesPage()
        {
            await Shell.Current.GoToAsync($"/grades?unit={RouteCode}");
        }

        async void GoToAssesmentPage()
        {
            await Shell.Current.GoToAsync($"/assesment?unit={RouteCode}");
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
