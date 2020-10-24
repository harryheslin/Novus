using MvvmHelpers;
using Novus.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Text;
using Telerik.XamarinForms.Input;

namespace Novus.ViewModels
{
    class PlanCalanderViewModel : BaseViewModel
    {
        Student student = App.Student;
         public PlanCalanderViewModel()
        {
            Classes = new ObservableCollection<Appointment>();
            GetAppointments();

        }

        private void GetAppointments()
        {
            foreach(Unit unit in student.CurrentUnits)
            {
                ObservableCollection<Appointment> lectures = GenerateAppointmentsFromClasses(unit.Lectures, unit);
                ObservableCollection<Appointment> tutorials = GenerateAppointmentsFromClasses(unit.Tutorials, unit);
            
                foreach(Appointment value in lectures)
                {
                    Classes.Add(value);
                }

                foreach (Appointment value in tutorials)
                {
                    Classes.Add(value);
                }
            }
        }

        private ObservableCollection<Appointment> GenerateAppointmentsFromClasses(ObservableCollection<Class> classes, Unit unit)
        {
            ObservableCollection<Appointment> returnValue = new ObservableCollection<Appointment>();
            foreach(Class value in classes)
            {
                if(value.Planned)
                {
                    returnValue.Add(GenerateAppointmentFromClass(value, unit));
                }
            }

            return returnValue;
        }

        private Appointment GenerateAppointmentFromClass(Class value, Unit unit)
        {
            return new Appointment
            {
                Title = String.Format("{0} {1} {2}", unit.Code, value.Type, value.Room),
                StartDate = new DateTime(2020, 6, 1 + GetDate(value.DayOfWeek), value.StartTime.Hour, value.StartTime.Minute, value.StartTime.Second),
                EndDate = new DateTime(2020, 6, 1 + GetDate(value.DayOfWeek), value.EndTime.Hour, value.EndTime.Minute, value.EndTime.Second),
                Color = GetColor(unit)
            };
        }

        private int GetDate(DayOfWeek value)
        {
            if (value == DayOfWeek.Monday) return 0;
            if (value == DayOfWeek.Tuesday) return 1;
            if (value == DayOfWeek.Wednesday) return 2;
            if (value == DayOfWeek.Thursday) return 3;
            
            return 4;
        }

        private Color GetColor(Unit unit)
        {
            if (unit.Code == "IFB102") return Color.Red;
            if (unit.Code == "IFB103") return Color.Blue;
            if (unit.Code == "IFB104") return Color.Yellow;

            return Color.Green;
        }

        ObservableCollection<Appointment> classes;
        public ObservableCollection<Appointment> Classes
        {
            get => classes;
            set
            {
                SetProperty(ref classes, value);
                OnPropertyChanged(nameof(Classes));
            }
        }
    }
}
