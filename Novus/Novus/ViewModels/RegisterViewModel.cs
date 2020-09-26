using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Novus.Models;
using Xamarin.Essentials;

namespace Novus.ViewModels
{
    class RegisterViewModel : BaseViewModel
    {
        public RegisterViewModel()
        {
            student = Student.GenerateStudent();
        }


        Student student;
        public Student Student
        {
            get => student;
            set
            {
                SetProperty(ref student, value);
                OnPropertyChanged(nameof(Student));
            }
        }

        public ObservableCollection<Semester> Enrollment
        {
            get => student.Enrollment;
        }

        public void SetIsVisible(int unitID)
        {
            bool secondBreak = false;
            foreach (Semester semester in Student.Enrollment)
            {
                if (secondBreak)
                {
                    break;
                }
                foreach(Unit unit in semester.EnrolledUnits)
                {
                    if(unit.UnitID == unitID)
                    {
                        unit.IsVisible = !unit.IsVisible;
                        Student.Enrollment[Student.Enrollment.IndexOf(semester)].EnrolledUnits[semester.EnrolledUnits.IndexOf(unit)] = unit;
                        secondBreak = true;
                        break;
                    }
                }
            }
        }

        public void AddUnit(int[] semesterNumber)
        {
            foreach(Semester semester in Student.Enrollment)
            {
                if(semester.SemesterNumber == semesterNumber)
                {
                    semester.EnrollInUnit(Unit.GenerateUnit());
                    Student.Enrollment[Student.Enrollment.IndexOf(semester)] = semester;
                    break;
                }
            }
        }

        public void RemoveUnit(int unitID)
        {
            bool secondBreak = false;
            foreach (Semester semester in Student.Enrollment)
            {
                foreach (Unit unit in semester.EnrolledUnits)
                {
                    if (unit.UnitID == unitID)
                    {
                        semester.UnEnrollInUnit(unit);
                        Student.Enrollment[Student.Enrollment.IndexOf(semester)] = semester;
                        secondBreak = true;
                        return;
                    }
                }
            }
        }
    }
}
