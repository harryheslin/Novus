using MvvmHelpers;
using Xamarin.Forms;
using Novus.Views;

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
