using System;
using System.Collections.Generic;
using System.Text;
using MvvmHelpers;
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

        public Semester[] Enrollment
        {
            get => student.Enrollment;
        }
        public void ShowOrHideUnit(Unit unit)
        {
            unit.IsVisible = !unit.IsVisible;
            Console.WriteLine(String.Format("{0} {1} {2}", unit.Semester[0], unit.Semester[1], unit.IsVisible));
            Student.Enrollment[unit.Semester[0]].Units[unit.Semester[1]] = unit;
        }
    }
}
