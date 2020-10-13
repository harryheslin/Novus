using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Essentials;
using MvvmHelpers;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Novus.Models;

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
            string unitNumber = Shell.Current.CurrentState.Location.ToString();

            switch (unitNumber)
            {
                case "//unit1":
                    return Student.CurrentUnits[0].Colour; //Green
                case "//IMPL_unit2/unit2":
                    return Student.CurrentUnits[1].Colour;  //Orange
                case "//IMPL_unit3/unit3":
                    return Student.CurrentUnits[2].Colour;  //Blue
                case "//IMPL_unit4/unit4":
                    return Student.CurrentUnits[3].Colour; //Yellow

                default:
                    return "White";
            }
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

        string RouteCode = Shell.Current.CurrentState.Location.ToString();
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
