using System;
using Novus.Models;
using MvvmHelpers;
using Xamarin.Forms;
using System.ComponentModel;

namespace Novus.ViewModels
{
    class EventAddViewModel : BaseViewModel
    {      
        public string NameInput { set; get; }
        public string DescriptionInput { set; get; }
        public Command AddEventButton { get; }
        private DateTime startDateSelected;
        public DateTime StartDateSelected
        {
            //get; set;
            get => startDateSelected;
            set
            {
                SetProperty(ref startDateSelected, value);
                OnPropertyChanged(nameof(StartDateSelected));
            }
        }

        DateTime endDateSelected;
        public DateTime EndDateSelected
        {
            //get; set;
            get => endDateSelected;
            set
            {
                SetProperty(ref endDateSelected, value);
                OnPropertyChanged(nameof(EndDateSelected));
            }
        }
        public string ColourSelected { get; set; }
        public bool AllDayToggle { set; get; }


        public DateTime Today { get; private set; }

        public EventAddViewModel()
        {
            AddEventButton = new Command(AddEventAndGoBack);
            Today = DateTime.Today;
            ColourSelected = "Red";
        }

        async void AddEventAndGoBack()
        {            
            if (EndDateSelected < StartDateSelected)
            {
                await Application.Current.MainPage.DisplayAlert("Check your dates!", "Please ensure the end date is after the start date","OK");
            }
            else if (EndDateSelected==StartDateSelected && !AllDayToggle)
            {
                await Application.Current.MainPage.DisplayAlert("Check your dates!","An event can not be zero minutes long. please selected a later" +
                    "date or turn the all day slider on","OK");
            }
            else
            {
                Events.AddToEvents(NameInput, DescriptionInput, StartDateSelected, EndDateSelected, ColourSelected, AllDayToggle);                
                await Shell.Current.GoToAsync("calendar");
            }
        }


    }
}
