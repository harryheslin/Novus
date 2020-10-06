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
        public CalendarWeekViewModel()
        {
            MonthViewButton = new Command(GoToMonthPage);
            DayViewButton = new Command(GoToDayPage);
            EventAddButton = new Command(GoToNew);
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
    }
}
