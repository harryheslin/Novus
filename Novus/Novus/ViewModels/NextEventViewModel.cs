using System.Collections.ObjectModel;
using MvvmHelpers;
using Novus.Models;
using Xamarin.Forms;
using Command = Xamarin.Forms.Command;

namespace Novus.ViewModels
{
    class NextEventViewModel : BaseViewModel
    {
        //set a private ObservableCollection for the current list of events
        ObservableCollection<Events> CurrentEvents = App.Student.Events;
        
        //define a command for going to calendar
        public Command ToCalendar { get; }


        //Set the propterty changes
        private string latestName;
        public string LatestName
        {
            get => latestName;
            set
            {
                SetProperty(ref latestName, value);
                OnPropertyChanged(nameof(LatestName));
            }
        }

        //Set the propterty changes
        private string latestDate;
        public string LatestDate
        {
            get => latestDate;
            set
            {
                SetProperty(ref latestDate, value);
                OnPropertyChanged(nameof(LatestDate));
            }
        }

        //Set the propterty changes
        private string latestDescription;
        public string LatestDescription
        {
            get => latestDescription;
            set
            {
                SetProperty(ref latestDescription, value);
                OnPropertyChanged(nameof(LatestDescription));
            }
        }

        //Set the propterty changes
        private Color latestColor;
        public Color LatestColor
        {
            get => latestColor;
            set
            {
                SetProperty(ref latestColor, value);
                OnPropertyChanged(nameof(LatestColor));
            }
        }

        //Set the propterty changes
        private Color textColour;
        public Color TextColour
        {
            get => textColour;
            set
            {
                SetProperty(ref textColour, value);
                OnPropertyChanged(nameof(TextColour));
            }
        }

        //constructor for the ViewModels
        public NextEventViewModel()
        {
            ToCalendar = new Command(GoToCalendar);
            GetLatestEvents();
        }

        //gets the latest event and updates the bindings
        private void GetLatestEvents()
        {
            if (CurrentEvents.Count == 0)
            {
                latestName = "No Events";
                latestDate = "No Date";
                latestDescription = "No Description";
                textColour = Color.Black;
                latestColor = Color.White;
            }
            else
            {
                Events latestEvents = CurrentEvents[0];
                for (int i = 0; i < CurrentEvents.Count; i++)
                {
                    if (CurrentEvents[i].StartDate < latestEvents.StartDate)
                    {
                        latestEvents = CurrentEvents[i];
                    }
                }
                latestName = latestEvents.EventName;
                latestDate = latestEvents.StartDate.ToString("dd/MM/yyyy hh:mmtt");
                if (latestEvents.EventDescription == null)
                {
                    latestDescription = "No Description";
                }
                else
                {
                    latestDescription = latestEvents.EventDescription;
                }
                latestColor = Events.ColourDeterminer(latestEvents.EventColour);
                textColour = Color.White;
            }
        }

        //Go to the calendar 
        async void GoToCalendar()
        {
            await Shell.Current.Navigation.PopAsync(false);
            await Shell.Current.GoToAsync("calendar", false);
        }
    }
}
