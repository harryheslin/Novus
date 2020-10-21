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
            string param = s.ToString();

            for(int i = 0; i < Student.CurrentUnits.Count; i++)
            {
                if(param == Student.CurrentUnits[i].Code)
                {
                    string path = "unit?unit=" + i + "&routeCode=" + i; 
                    await Shell.Current.GoToAsync($"{path}");
                }
            }
        }


    }
}
