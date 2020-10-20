using MvvmHelpers;
using Novus.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Novus.ViewModels
{
    [QueryProperty("Unit", "unit")]
    class UnitGradesViewModel : BaseViewModel
    {
        public Command OpenFile { get; }

        static Student Student = App.Student;

        static public Unit currentUnit = Student.CurrentUnits[0];

        public UnitGradesViewModel()
        {
            OpenFile = new Command(GoToOpenFilePage);
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
                OnPropertyChanged(nameof(GradedAssesment));
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

        private ObservableCollection<Assesment> GetGradedAssesment()
        {
            ObservableCollection<Assesment> result = new ObservableCollection<Assesment>();
            foreach(Assesment assesment in currentUnit.Assesments)
            {
                if (assesment.Graded == true)
                {
                    result.Add(assesment);
                }
            }
            return result;
        }

        private ObservableCollection<Assesment> NoGradedAssesment()
        {
            ObservableCollection<Assesment> emptyGradedAssesment = new ObservableCollection<Assesment>();
            emptyGradedAssesment.Add(new Assesment("", "No Grades Available", 0, "", "", false, "", "", "false"));
            return emptyGradedAssesment;
        }

        ObservableCollection<Assesment> gradedAssesment;
        public ObservableCollection<Assesment> GradedAssesment
        {
            get => (GetGradedAssesment()).Count == 0 ? NoGradedAssesment() : GetGradedAssesment();
            set
            {
                SetProperty(ref gradedAssesment, GetGradedAssesment());
                OnPropertyChanged();
            }
        }

        async void GoToOpenFilePage(Object s)
        {
            string param = s.ToString();
            await Shell.Current.GoToAsync($"file?name={param}");
        }
    }
}
