using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Essentials;
using MvvmHelpers;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Novus.ViewModels
{
    class UnitPageViewModel : BaseViewModel
    {
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

        string unit = Shell.Current.CurrentItem.Title;

        public string Unit
        {
            get => unit;
            set
            {
                SetProperty(ref unit, Uri.UnescapeDataString(value));
                OnPropertyChanged(nameof(Unit));
            }
        }

        string colour = UnitColour();
        public string Colour
        {
            get => colour;
            set
            {
                SetProperty(ref colour, UnitColour());
                OnPropertyChanged(nameof(Unit));
            }
        }

        
        static string UnitColour()
        {
            string unitNumber = Shell.Current.CurrentState.Location.ToString();

            switch (unitNumber)
            {
                case "//unit1":
                    return "#80EE8B";
                case "//IMPL_unit2/unit2":
                    return "#F3B15B";
                case "//IMPL_unit3/unit3":
                    return "#A1F1F4";
                case "//IMPL_unit4/unit4":
                    return "#EFE379";
                default:
                    return "white";
            }
        }
        async void GoToResourcesPage()
        {
            await Shell.Current.GoToAsync($"resources?unit={Unit}&colour={Colour}");
        }

        async void GoToAnnouncementsPage()
        {
            await Shell.Current.GoToAsync($"announcements?unit={Unit}&colour={Colour}");
        }

        async void GoToGradesPage()
        {
            await Shell.Current.GoToAsync($"grades?unit={Unit}&colour={Colour}");
        }

        async void GoToAssesmentPage()
        {
            await Shell.Current.GoToAsync($"announcements?unit={Unit}&colour={Colour}");
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
