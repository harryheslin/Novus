﻿using MvvmHelpers;
using Novus.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Novus.ViewModels
{
    [QueryProperty("Unit", "unit")]
    class UnitAnnouncementsViewModel : BaseViewModel
    {
        static Student Student = Student.GenerateStudent();

        static public Unit currentUnit = Student.Enrollment[0].Units[0];

        public string GetUnitNumber(string routeCode)
        {
            switch (routeCode)
            {
                case "/unit1":
                    currentUnit = Student.Enrollment[0].Units[0];
                    return currentUnit.FullName;
                case "/IMPL_unit2/unit2":
                    currentUnit = Student.Enrollment[0].Units[1];
                    return currentUnit.FullName;
                case "/IMPL_unit3/unit3":
                    currentUnit = Student.Enrollment[0].Units[2];
                    return currentUnit.FullName;
                case "/IMPL_unit4/unit4":
                    currentUnit = Student.Enrollment[0].Units[3];
                    return currentUnit.FullName;
                default:
                    return "Error";
            }
        }

        string unit;
        public string Unit
        {
            get => unit;
            set
            {
                SetProperty(ref unit, GetUnitNumber(Uri.UnescapeDataString(value)));
                OnPropertyChanged(nameof(Announcements));
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

        Announcement[] announcements;
        public Announcement[] Announcements
        {
            get => currentUnit.StaffAnnouncements;
            set
            {
                SetProperty(ref announcements, currentUnit.StaffAnnouncements);
                OnPropertyChanged();
            }
        }
    }
}
