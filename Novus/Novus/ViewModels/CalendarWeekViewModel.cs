using System;
using System.Collections.Generic;
using System.Text;
using MvvmHelpers;
using Xamarin.Forms;

namespace Novus.ViewModels
{
    class CalendarWeekViewModel : BaseViewModel
    {
        public Command MonthViewButton { get; }
        public Command DayViewButton { get; }
        public Command EventAddButton { get; }
        public Command SettingsButton { get; }
        public CalendarWeekViewModel()
        {
            MonthViewButton = new Command(GoToMonthPage);
            DayViewButton = new Command(GoToDayPage);
            EventAddButton = new Command(GoToNew);
            SettingsButton = new Command(GoToSettings);
        }

        async void GoToMonthPage()
        {
            await Shell.Current.GoToAsync("calendar");
        }

        async void GoToDayPage()
        {
            await Shell.Current.GoToAsync("calendarDay");
        }
        async void GoToNew()
        {
            await Shell.Current.GoToAsync("eventAdd");
        }

        async void GoToSettings()
        {
            await Shell.Current.GoToAsync("calendarSettings");
        }
    }
}
