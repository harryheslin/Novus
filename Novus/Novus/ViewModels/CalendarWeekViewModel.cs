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

        //go to the month page
        async void GoToMonthPage()
        {
            await Shell.Current.GoToAsync("calendar");
            Shell.Current.Navigation.RemovePage(Shell.Current.Navigation.NavigationStack[Shell.Current.Navigation.NavigationStack.Count - 2]);
        }

        //go to the day page
        async void GoToDayPage()
        {
            await Shell.Current.GoToAsync("calendarDay");
            Shell.Current.Navigation.RemovePage(Shell.Current.Navigation.NavigationStack[Shell.Current.Navigation.NavigationStack.Count - 2]);
        }

        //go to the new event page
        async void GoToNew()
        {  
            await Shell.Current.GoToAsync("eventAdd");
        }
    }
}
