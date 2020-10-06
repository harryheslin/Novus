using MvvmHelpers;
using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novus.ViewModels
{
    class CalendarViewModel : BaseViewModel
    {
        public Command DayViewButton { get; }

        public Command WeekViewButton { get; }

        public Command EventAddButton { get; }

        public Command SettingsButton { get; }

        public CalendarViewModel()
        {
            DayViewButton = new Command(GoToDayPage);
            WeekViewButton = new Command(GoToWeekPage);
            EventAddButton = new Command(GoToNew);            
        }

        async void GoToDayPage()
        {
            await Shell.Current.GoToAsync("calendarDay");
        }

        async void GoToWeekPage()
        {
            await Shell.Current.GoToAsync("calendarWeek");
        }

        async void GoToNew()
        {
            await Shell.Current.GoToAsync("eventAdd");
        }
    }
}
