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
            int route = Int32.Parse(routeCode);
            currentUnit = Student.CurrentUnits[route];
            return currentUnit.FullName;

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

        //private ObservableCollection<Assesment> getCurrentAssesment()
        //{
        //    ObservableCollection<Assesment> result = new ObservableCollection<Assesment>(); 
        //    foreach(Assesment assesment in currentUnit.Assesments)
        //    {
        //        if (assesment.ReleaseDate != "TBC")
        //            {
        //                assesment.Grade = "True";                       
        //            }
        //        result.Add(assesment); 
        //    }
        //    return result;
        //}

        private ObservableCollection<Assesment> NoAssesment()
        {
            ObservableCollection<Assesment> emptyAssesment = new ObservableCollection<Assesment>();
            emptyAssesment.Add(new Assesment("False", "No Assesment Available", 0, "", "", false, "", "", "false"));
            return emptyAssesment;
        }

        ObservableCollection<Assesment> assesment;
        public ObservableCollection<Assesment> Assesments
        {
            get => (currentUnit.Assesments).Count == 0 ? NoAssesment() : currentUnit.Assesments;
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
