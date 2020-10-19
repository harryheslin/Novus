using System;
using Novus.Models;
using MvvmHelpers;
using Xamarin.Forms;
using System.IO;

namespace Novus.ViewModels
{
    class EventAddViewModel : BaseViewModel
    {
        Student student = App.Student;

        //Event Name Preoperty changed
        string nameInput;
        public string NameInput
        {
            get => nameInput;
            set
            {
                SetProperty(ref nameInput, value);
                OnPropertyChanged(nameof(NameInput));
            }
        }

        //Descrption Property changed
        string descriptionInput;
        public string DescriptionInput
        {
            get => descriptionInput;
            set
            {
                SetProperty(ref descriptionInput, value);
                OnPropertyChanged(nameof(DescriptionInput));
            }
        }

        private DateTime startDateSelected;
        public DateTime StartDateSelected
        {
            get => startDateSelected;
            set
            {
                SetProperty(ref startDateSelected, value);
                OnPropertyChanged(nameof(StartDateSelected));
                if (StartDateSelected > EndDateSelected)
                {
                    OnPropertyChanged(nameof(EndDateSelected));
                }
            }
        }

        DateTime endDateSelected;
        public DateTime EndDateSelected
        {
            get => endDateSelected;
            set
            {
                SetProperty(ref endDateSelected, value);
                OnPropertyChanged(nameof(EndDateSelected));
            }
        }

        //Colour Proterty Change
        string colourSelected;
        public string ColourSelected
        {
            get => colourSelected;
            set
            {
                SetProperty(ref colourSelected, value);
                OnPropertyChanged(nameof(ColourSelected));
            }
        }

        //All Day Property Change
        bool allDayToggle;
        public bool AllDayToggle
        {
            get => allDayToggle;
            set
            {
                SetProperty(ref allDayToggle, value);
                OnPropertyChanged(nameof(AllDayToggle));
            }
        }

        //Current time for minimum start selection
        public DateTime Today { get; private set; }

        public Command AddEventButton { get; }


        public EventAddViewModel()
        {
            AddEventButton = new Command(AddEventAndGoBack);
            Today = DateTime.Today;
            ColourSelected = "Red";
        }

        //when exicuted adds event to database and goes back to previous screen
        async void AddEventAndGoBack()
        {
            //if the end date is before the start date then display apropriate error pop up
            if (EndDateSelected < StartDateSelected)
            {
                await Application.Current.MainPage.DisplayAlert("Check your dates!", "Please ensure the end date is after the start date", "OK");
            }
            //if the end date is the same as the start date and the event is not all day then display apropriate error pop up
            else if (EndDateSelected == StartDateSelected && !AllDayToggle)
            {
                await Application.Current.MainPage.DisplayAlert("Check your dates!", "An event can not be zero minutes long. please selected a later" +
                    "date or turn the all day slider on", "OK");
            }
            //if no name is entered display apropriate error pop up
            else if (NameInput == null)
            {
                await Application.Current.MainPage.DisplayAlert("No Name", "Please ensure an event name has been enter", "OK");
            }
            else
            {
                //create new instant of event
                Events e = new Events(student.Events.Count + 1, NameInput, DescriptionInput, StartDateSelected, EndDateSelected, ColourSelected, AllDayToggle);
                //add the created event into the database
                student.Events.Add(e);

                //get the name of ther prior page
                string priorPage = (Shell.Current.Navigation.NavigationStack[Shell.Current.Navigation.NavigationStack.Count - 2]).ToString();

                //remove the prior page and pop current page
                Shell.Current.Navigation.RemovePage(Shell.Current.Navigation.NavigationStack[Shell.Current.Navigation.NavigationStack.Count - 2]);
                await Shell.Current.Navigation.PopAsync(false);

                //if the prior page was the month view open month view
                if (priorPage == "Novus.Views.Calendar")
                {
                    await Shell.Current.GoToAsync("calendar", false);
                }

                //if the prior page was the week view open week view
                else if (priorPage == "Novus.Views.CalendarWeek")
                {
                    await Shell.Current.GoToAsync("calendarWeek", false);

                }

                //if the prior page was the day view open day view
                else if (priorPage == "Novus.Views.CalendarDay")
                {
                    await Shell.Current.GoToAsync("calendarDay", false);

                }
            }
        }
    }
}
