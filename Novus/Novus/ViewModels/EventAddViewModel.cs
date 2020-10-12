using System;
using Novus.Models;
using MvvmHelpers;
using Xamarin.Forms;

namespace Novus.ViewModels
{
    class EventAddViewModel : BaseViewModel
    {
        public string NameInput
        { get; set; }
        public string DescriptionInput { set; get; }
        public Command AddEventButton { get; }
        public DateTime EndDateMinimum => StartDateSelected.AddMinutes(1);

        private DateTime startDateSelected;
        public DateTime StartDateSelected
        {
            get => startDateSelected;
            set
            {
                SetProperty(ref startDateSelected, value);
                OnPropertyChanged(nameof(StartDateSelected));
                OnPropertyChanged(nameof(EndDateMinimum));
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
                Events.AddToEvents(NameInput, DescriptionInput, StartDateSelected, EndDateSelected, ColourSelected, AllDayToggle);

                string x = (Shell.Current.Navigation.NavigationStack[Shell.Current.Navigation.NavigationStack.Count - 2]).ToString();

                Console.WriteLine(x);

                Shell.Current.Navigation.RemovePage(Shell.Current.Navigation.NavigationStack[Shell.Current.Navigation.NavigationStack.Count - 2]);
                Shell.Current.Navigation.PopAsync(false);

                if (x == "Novus.Views.Calendar")
                {
                    await Shell.Current.GoToAsync("calendar", false);
                }
                else if (x == "Novus.Views.CalendarWeek")
                {
                    await Shell.Current.GoToAsync("calendarWeek", false);

                }
                else if (x == "Novus.Views.CalendarDay")
                {
                    await Shell.Current.GoToAsync("calendarDay", false);

                }
            }
        }
    }
}
