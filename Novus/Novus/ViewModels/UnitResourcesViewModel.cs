using MvvmHelpers;
using Novus.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Novus.ViewModels
{
    [QueryProperty("Unit", "unit")]
    class UnitResourcesViewModel : BaseViewModel
    {
        public Command LecturePage { get; }

        public Command OpenFile { get;  }

        static Student Student = App.Student;

        static public Unit currentUnit = Student.CurrentUnits[0];

        public UnitResourcesViewModel()
        {
            LecturePage = new Command(GoToLecturePage);
            OpenFile = new Command(GoToOpenFilePage);
        }

        public string GetUnitNumber(string routeCode)
        {
            int route = Int32.Parse(routeCode);
            currentUnit = Student.CurrentUnits[route];
            return currentUnit.FullName;

        }

        public void SetIsVisible(string week)
        {
            for (int i = 0; i < UnitResources.Count; i++)
            {
                if (week == UnitResources[i].Week)
                {
                    Resources currentWeek = UnitResources[i];
                    currentWeek.IsVisible = !UnitResources[i].IsVisible;
                    UnitResources[i] = currentWeek;
                    return;
                }
            }
        }

        string unit;
        public string Unit
        {
            get => unit;
            set
            {
                SetProperty(ref unit, GetUnitNumber(Uri.UnescapeDataString(value)));
                OnPropertyChanged(nameof(UnitResources));
                OnPropertyChanged(nameof(Colour));
            }
        }

        string colour;
        public string Colour
        {
            get => currentUnit.Colour;
            set
            {
                SetProperty(ref colour, currentUnit.Colour);
                OnPropertyChanged();
            }
        }

        ObservableCollection<Resources> unitResources;
        public ObservableCollection<Resources> UnitResources
        {
            get => currentUnit.UnitResources;
            set
            {
                SetProperty(ref unitResources, currentUnit.UnitResources);
                OnPropertyChanged();
            }
        }

        async void GoToLecturePage()
        {
            string Echo360Page = "https://play.google.com/store/apps/details?id=com.echo360.echoupload&hl=en_AU";
            await Launcher.OpenAsync(Echo360Page);
        }

        async void GoToOpenFilePage(Object s)
        {
            string colour = currentUnit.Colour;
            string param = s.ToString();
            await Shell.Current.GoToAsync($"file?name={param}");
        }

    }
}
