using MvvmHelpers;
using Xamarin.Forms;

namespace Novus.ViewModels
{
    class CalendarHomeViewModel : BaseViewModel
    {
        public Command MonthViewButton { get; }
        public Command WeekViewButton { get; }
        public Command DayViewButton { get; }

        public CalendarHomeViewModel()
        {
            MonthViewButton = new Command(GoToMonthPage);
            WeekViewButton = new Command(GoToWeekPage);
            DayViewButton = new Command(GoToDayPage);
        }

        async void GoToMonthPage()
        {
            await Shell.Current.GoToAsync("calendar");
        }
        async void GoToWeekPage()
        {
            await Shell.Current.GoToAsync("calendarWeek");
        }
        async void GoToDayPage()
        {
            await Shell.Current.GoToAsync("calendarDay");
        }
    }
}
