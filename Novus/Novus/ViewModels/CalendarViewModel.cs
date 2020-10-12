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

        //private static var page = new Calendar();
        public CalendarViewModel()
        {
            DayViewButton = new Command(GoToDayPage);
            WeekViewButton = new Command(GoToWeekPage);
            EventAddButton = new Command(GoToNew);
        }

        async void GoToDayPage()
        {
            await Shell.Current.GoToAsync("calendarDay");
            Shell.Current.Navigation.RemovePage(Shell.Current.Navigation.NavigationStack[Shell.Current.Navigation.NavigationStack.Count - 2]);
        }

        async void GoToWeekPage()
        {
            await Shell.Current.GoToAsync("calendarWeek");
            Shell.Current.Navigation.RemovePage(Shell.Current.Navigation.NavigationStack[Shell.Current.Navigation.NavigationStack.Count - 2]);

        }

        async void GoToNew()
        {
            await Shell.Current.GoToAsync("eventAdd");
        }
    }
}
