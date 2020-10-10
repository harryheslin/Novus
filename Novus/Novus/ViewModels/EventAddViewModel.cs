using System;
using Novus.Models;
using MvvmHelpers;
using Xamarin.Forms;

namespace Novus.ViewModels
{
    class EventAddViewModel : BaseViewModel
    {

        //public PropertyChangingEventHandler StartDateChange;

        public string NameInput { set; get; }
        public string DescriptionInput { set; get; }
        public Command AddEventButton { get; }
        DateTime startDateSelected;
        public DateTime StartDateSelected
        {
            get; set;
            //get=> startDateSelected;
            //set
            //{            
            //    SetProperty(ref startDateSelected, value);
            //    OnPropertyChanged(nameof(StartDateSelected));
            //}
        }

        //DateTime endDateSelected;
        public DateTime EndDateSelected
        {
            get; set;
            //get=> endDateSelected;
            //set
            //{
            //    SetProperty(ref endDateSelected, value);
            //    OnPropertyChanged(nameof(StartDateSelected));
            //}
        }
        public string ColourSelected { get; set; }
        public bool AllDayToggle { set; get; }


        public DateTime Today { get; private set; }

        public EventAddViewModel()
        {
            AddEventButton = new Command(AddEventAndGoBack);
            Today = DateTime.Now;
            ColourSelected = "Red";
        }

        async void AddEventAndGoBack()
        {
            Events.AddToEvents(NameInput, DescriptionInput, StartDateSelected, EndDateSelected, ColourSelected, AllDayToggle);
            await Shell.Current.Navigation.PopAsync();
            //Console.WriteLine(EndDateSelected);
        }
    }
}
