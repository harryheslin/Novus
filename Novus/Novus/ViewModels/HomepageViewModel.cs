using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Novus.ViewModels
{
    class HomepageViewModel : BaseViewModel 
    {
        public Command OpenMyUnitsPage { get; }
        public Command CalendarPage { get; }
        public Command EmailPage { get; }

        public HomepageViewModel()
        {
            OpenMyUnitsPage = new Command(GoToMyUnitsPage);
            CalendarPage = new Command(GoToCalendarPage);
            EmailPage = new Command(GoToEmailPage);
        }

        async void GoToMyUnitsPage()
        {
            await Shell.Current.GoToAsync($"myUnitsPage");
        }

        async void GoToCalendarPage()
        {
            await Shell.Current.GoToAsync($"calendarHome");
        }

        async void GoToEmailPage()
        {
            string EmailPage = "https://play.google.com/store/apps/details?id=com.google.android.gm&hl=en_AU&gl=US";
            await Launcher.OpenAsync(EmailPage);
        }
    }
}
