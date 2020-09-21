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

        public CalendarDayViewModel()
        {
            MonthViewButton = new Command(GoToMonthPage);
        }

        async void GoToMonthPage()
        {
            await Shell.Current.GoToAsync("calendar");
        }
    }
}
