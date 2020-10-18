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
        public bool AllDayToggle { get => allDayToggle;
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

        async void AddEventAndGoBack()
        {
            if (EndDateSelected < StartDateSelected)
            {
                await Application.Current.MainPage.DisplayAlert("Check your dates!", "Please ensure the end date is after the start date", "OK");
            }
            else if (EndDateSelected == StartDateSelected && !AllDayToggle)
            {
                await Application.Current.MainPage.DisplayAlert("Check your dates!", "An event can not be zero minutes long. please selected a later" +
                    "date or turn the all day slider on", "OK");
            }
            else if (NameInput == null)
            {
                await Application.Current.MainPage.DisplayAlert("No Name", "Please ensure an event name has been enter", "OK");
            }
            else
            {
                Events e = new Events(student.Events.Count+1, NameInput, DescriptionInput, StartDateSelected, EndDateSelected, ColourSelected, AllDayToggle);
                student.Events.Add(e);

                string priorPage = (Shell.Current.Navigation.NavigationStack[Shell.Current.Navigation.NavigationStack.Count - 2]).ToString();

                Console.WriteLine(priorPage);

                Shell.Current.Navigation.RemovePage(Shell.Current.Navigation.NavigationStack[Shell.Current.Navigation.NavigationStack.Count - 2]);
                await Shell.Current.Navigation.PopAsync(false);

                if (priorPage == "Novus.Views.Calendar")
                {
                    await Shell.Current.GoToAsync("calendar", false);
                }
                else if (priorPage == "Novus.Views.CalendarWeek")
                {
                    await Shell.Current.GoToAsync("calendarWeek", false);

                }
                else if (priorPage == "Novus.Views.CalendarDay")
                {
                    await Shell.Current.GoToAsync("calendarDay", false);

                }
            }
        }
    }
}
