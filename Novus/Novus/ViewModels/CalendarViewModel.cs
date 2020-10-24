using MvvmHelpers;
using Xamarin.Forms;

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

        //go to the day page
        async void GoToDayPage()
        {
            await Shell.Current.GoToAsync("calendarDay");
            Shell.Current.Navigation.RemovePage(Shell.Current.Navigation.NavigationStack[Shell.Current.Navigation.NavigationStack.Count - 2]);
        }

        //go to the week page
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
