using MvvmHelpers;
using Novus.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Novus.ViewModels
{
    [QueryProperty("Unit", "unit")]
    class UnitAssesmentViewModel : BaseViewModel
    {
        public Command SubmissionPage { get; }

        static Student Student = App.Student;

        static public Unit currentUnit = Student.CurrentUnits[0];

        public UnitAssesmentViewModel()
        {
            SubmissionPage = new Command(GoToSubmissionPage);
        }
        public string GetUnitNumber(string routeCode)
        {
            switch (routeCode)
            {
                case "/unit1":
                    currentUnit = Student.CurrentUnits[0];
                    return currentUnit.FullName;
                case "/IMPL_unit2/unit2":
                    currentUnit = Student.CurrentUnits[1];
                    return currentUnit.FullName;
                case "/IMPL_unit3/unit3":
                    currentUnit = Student.CurrentUnits[2];
                    return currentUnit.FullName;
                case "/IMPL_unit4/unit4":
                    currentUnit = Student.CurrentUnits[3];
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
                OnPropertyChanged(nameof(Assesments));
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

        private ObservableCollection<Assesment> getCurrentAssesment(){
            ObservableCollection<Assesment> result = new ObservableCollection<Assesment>(); 
            foreach(Assesment assesment in currentUnit.Assesments)
            {
                if (assesment.Graded == false)
                {
                    if (assesment.ReleaseDate == "TBC")
                        assesment.Grade = "False";
                    result.Add(assesment);
                }   
            }
            return result;
        }

        ObservableCollection<Assesment> assesment;
        public ObservableCollection<Assesment> Assesments
        {
            get => getCurrentAssesment();
            set
            {
                SetProperty(ref assesment, currentUnit.Assesments);
                OnPropertyChanged();
            }
        }

        async void GoToSubmissionPage()
        {
            string TurnitinPage= "https://www.turnitin.com/";
            await Launcher.OpenAsync(TurnitinPage);
        }
    }
}
