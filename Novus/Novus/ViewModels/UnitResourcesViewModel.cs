﻿using MvvmHelpers;
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

        static Student Student = Student.GenerateStudent(4);

        static public Unit currentUnit = Student.Enrollment[0].EnrolledUnits[0];
        
        public UnitResourcesViewModel()
        {
            LecturePage = new Command(GoToLecturePage);
        }

        public string GetUnitNumber(string routeCode)
        {
            switch (routeCode)
            {
                case "/unit1":
                    currentUnit = Student.Enrollment[0].EnrolledUnits[0];
                    return currentUnit.FullName;
                case "/IMPL_unit2/unit2":
                    currentUnit = Student.Enrollment[0].EnrolledUnits[1];
                    return currentUnit.FullName;
                case "/IMPL_unit3/unit3":
                    currentUnit = Student.Enrollment[0].EnrolledUnits[2];
                    return currentUnit.FullName;
                case "/IMPL_unit4/unit4":
                    currentUnit = Student.Enrollment[0].EnrolledUnits[3];
                    return currentUnit.FullName;
                default:
                    return "Error";
            }
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

        List<Resources> unitResources;
        public List<Resources> UnitResources
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

    }
}
