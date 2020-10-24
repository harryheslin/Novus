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

        public CalendarDayViewModel()
        {
            MonthViewButton = new Command(GoToMonthPage);
            WeekViewButton = new Command(GoToWeekPage);
            EventAddButton = new Command(GoToNew);            
        }

        //go to month page
        async void GoToMonthPage()
        {
            await Shell.Current.GoToAsync("calendar");
            Shell.Current.Navigation.RemovePage(Shell.Current.Navigation.NavigationStack[Shell.Current.Navigation.NavigationStack.Count - 2]);

        }

        //go to week page
        async void GoToWeekPage()
        {
            await Shell.Current.GoToAsync("calendarWeek");
            Shell.Current.Navigation.RemovePage(Shell.Current.Navigation.NavigationStack[Shell.Current.Navigation.NavigationStack.Count - 2]);

        }

        //go to the new event page
        async void GoToNew()
        {
            await Shell.Current.GoToAsync("eventAdd");
        }        
    }
}
