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

        //go to month page
        async void GoToMonthPage()
        {
            await Shell.Current.GoToAsync("calendar");
        }
        
        //go to week page
        async void GoToWeekPage()
        {
            await Shell.Current.GoToAsync("calendarWeek");
        }

        //go to day page
        async void GoToDayPage()
        {
            await Shell.Current.GoToAsync("calendarDay");
        }
    }
}
