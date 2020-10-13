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
            student = App.Student;
        }


        Student student;
        public Student Student
        {
            get => student;
            set
            {
                App.Student = value;
                SetProperty(ref student, App.Student);
                OnPropertyChanged(nameof(Student));
            }
        }

        public ObservableCollection<Semester> Enrollment
        {
            get => student.Enrollment;
        }

        public void SetIsVisible(int unitID)
        {
            Unit unit = GetUnit(unitID);
            if(unit.UnitID != -1)
            {
                unit.IsVisible = !unit.IsVisible;
                SetUnitValue(unit);
            }
        }

        public void AddUnit(ObservableCollection<int> semesterNumber)
        {
            Semester semester = GetSemester(semesterNumber);
            if(!semester.SemesterNumber.Equals(new ObservableCollection<int> { -1, -1 }))
            {
                //ADD NEW UNIT HERE
                SetSemesterValue(semester);
            }
        }

        public void RemoveUnit(int unitID)
        {
            Semester semester = GetSemester(unitID);
            if(!semester.SemesterNumber.Equals(new ObservableCollection<int>{ -1, -1 }))
            {
                Unit unit = GetUnit(unitID);

                if(unit.UnitID != -1)
                {
                    semester.UnEnrollInUnit(unit);
                    SetSemesterValue(semester);
                }
            }
        }

        private void SetUnitValue(Unit newValue) {
            try {
                int[] index = Semester.GetUnitIndex(Student.Enrollment, newValue);
                Student.Enrollment[index[0]].EnrolledUnits[index[1]] = newValue;
            } catch
            {
                return;
            }
        }

        private Unit GetUnit(Unit indexingUnit)
        {
            int[] semesterIndex = Semester.GetUnitIndex(Student.Enrollment, indexingUnit);
            if (semesterIndex != new int[] { -1, -1 })
            {
                return Student.Enrollment[semesterIndex[0]].EnrolledUnits[semesterIndex[1]];
            }
            else
            {
                return new Unit();
            }
        }

        private Unit GetUnit(int indexingUnitID)
        {
            int[] semesterIndex = Semester.GetUnitIndex(Student.Enrollment, indexingUnitID);
            if (semesterIndex != new int[] { -1, -1 })
            {
                return Student.Enrollment[semesterIndex[0]].EnrolledUnits[semesterIndex[1]];
            }
            else
            {
                return new Unit();
            }
        }

        private void SetSemesterValue(Semester newValue)
        {
            try
            {
                int index = Semester.GetSemesterIndex(Student.Enrollment, newValue);
                Student.Enrollment[index] = newValue;
            }
            catch
            {
                return;
            }
        }

        private Semester GetSemester(ObservableCollection<int> semesterNumber)
        {
            int semesterIndex = Semester.GetSemesterIndex(Enrollment, semesterNumber);
            if(semesterIndex != -1)
            {
                return Student.Enrollment[semesterIndex];
            } 
            else
            {
                return new Semester();
            }
        }

        private Semester GetSemester(Semester semester)
        {
            int semesterIndex = Semester.GetSemesterIndex(Enrollment, semester);
            if (semesterIndex != -1)
            {
                return Student.Enrollment[semesterIndex];
            }
            else
            {
                return new Semester();
            }
        }

        private Semester GetSemester(Unit unit)
        {
            int[] semesterIndex = Semester.GetUnitIndex(Enrollment, unit);
            if(semesterIndex != new int[] { -1, -1 })
            {
                return Enrollment[semesterIndex[0]];
            } 
            else
            {
                return new Semester();
            }
        }

        private Semester GetSemester(int unitID)
        {
            int[] semesterIndex = Semester.GetUnitIndex(Enrollment, unitID);
            if (semesterIndex != new int[] { -1, -1 })
            {
                return Enrollment[semesterIndex[0]];
            }
            else
            {
                return new Semester();
            }
        }
    }
}
