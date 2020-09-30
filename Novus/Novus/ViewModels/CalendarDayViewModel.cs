using MvvmHelpers;
using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novus.ViewModels
{
    class CalendarDayViewModel : BaseViewModel
    {
        public Command MonthViewButton { get; }
        public Command WeekViewButton { get; }
        public Command EventAddButton { get; }
        public Command SettingsButton { get; }

        public CalendarDayViewModel()
        {
            MonthViewButton = new Command(GoToMonthPage);
            WeekViewButton = new Command(GoToWeekPage);
            EventAddButton = new Command(GoToNew);
            SettingsButton = new Command(GoToSettings);
        }

        async void GoToMonthPage()
        {
            await Shell.Current.GoToAsync("calendar");
        }

        async void GoToWeekPage()
        {
            await Shell.Current.GoToAsync("calendarWeek");
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
