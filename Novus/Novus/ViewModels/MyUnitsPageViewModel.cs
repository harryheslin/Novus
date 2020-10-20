using MvvmHelpers;
using Novus.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Novus.ViewModels
{
    class MyUnitsPageViewModel : BaseViewModel
    {
        static Student Student = App.Student;

        public Command UnitPage { get; }

        public Command CalendarPage { get; }

        public MyUnitsPageViewModel()
        {
            UnitPage = new Command (GoToUnitPage);
            CalendarPage = new Command(GoToCalendarPage);
        }

        ObservableCollection<Unit> currentUnits;
        
        public ObservableCollection<Unit> CurrentUnits
        {
            get => Student.CurrentUnits;
            set
            {
                SetProperty(ref currentUnits, Student.CurrentUnits);
            }
        }
        async void GoToCalendarPage()
        {
            await Shell.Current.GoToAsync($"calendarHome");
        }
        async void GoToUnitPage(Object s)
        {
            //string param = s.ToString();
            //switch (param)
            //{
            //    case "IFB102":
            //        await Shell.Current.GoToAsync($"unit1");
            //        break;
            //    case "IFB103":
                    await Shell.Current.GoToAsync($"unit1");
                    //break;
                //case "IFB104":
                //    await Shell.Current.GoToAsync($"unit3");
                //    break;
                //case "IFB105":
                //    await Shell.Current.GoToAsync($"unit4");
                //    break;
            //}         
            
        }

    }
}
