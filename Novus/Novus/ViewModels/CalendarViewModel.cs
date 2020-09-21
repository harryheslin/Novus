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

        public CalendarViewModel()
        {
            DayViewButton = new Command(GoToDayPage);
        }

        async void GoToDayPage()
        {
            await Shell.Current.GoToAsync("calendarDay");
        }
    }
}
