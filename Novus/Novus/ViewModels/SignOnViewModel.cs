using MvvmHelpers;
using Novus.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Novus.ViewModels
{
    class SignOnViewModel : BaseViewModel
    {
        public SignOnViewModel()
        {
            student = Student.GenerateStudent(3);
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

        public ObservableCollection<Unit> Units
        {
            get => student.Enrollment[0].EnrolledUnits;
        }

        public void SetIsVisible(int unitID)
        { 
            Unit unit = GetUnit(unitID);
            if (unit.UnitID != -1)
            {
                unit.IsVisible = !unit.IsVisible;
                SetUnitValue(unit);
            }
        }

        public void RegisterForClass(string tag)
        {
            try
            {
                string[] tagSplit = tag.Split('|');
                 Class classs = GetClass(int.Parse(tagSplit[1]));
                if (classs.ClassID != -1)
                {
                    Semester semester = GetSemester(classs.UnitID);
                    if (classs.Registerd)
                    {
                        semester.EnrollInClass(classs);
                    }
                    else
                    {
                        semester.UnEnrollInClass(classs);
                    }

                    SetSemesterValue(semester);
                }
            } 
            catch
            {
                return;
            }
            
        }

        private Class GetClass(int classID)
        {
            foreach(Unit unit in Units)
            {
                int classIndex = Class.GetClassIndex(unit.Classes, classID);
                if(classIndex != -1)
                {
                    return Student.Enrollment[0].EnrolledUnits[Unit.GetUnitIndex(Student.Enrollment[0].EnrolledUnits, unit.UnitID)].Classes[classIndex];
                }
            }
            return new Class();
        }

        private void SetUnitValue(Unit newValue)
        {
            try
            {
                int[] index = Semester.GetUnitIndex(Student.Enrollment, newValue);
                Student.Enrollment[index[0]].EnrolledUnits[index[1]] = newValue;
            }
            catch
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
                Student.Enrollment[0] = newValue;
            }
            catch
            {
                return;
            }
        }

        private Semester GetSemester(int[] semesterNumber)
        {
            int semesterIndex = Semester.GetSemesterIndex(Student.Enrollment, semesterNumber);
            if (semesterIndex != -1)
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
            int semesterIndex = Semester.GetSemesterIndex(Student.Enrollment, semester);
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
            int[] semesterIndex = Semester.GetUnitIndex(Student.Enrollment, unit);
            if (semesterIndex != new int[] { -1, -1 })
            {
                return Student.Enrollment[semesterIndex[0]];
            }
            else
            {
                return new Semester();
            }
        }

        private Semester GetSemester(int unitID)
        {
            int[] semesterIndex = Semester.GetUnitIndex(Student.Enrollment, unitID);
            if (semesterIndex != new int[] { -1, -1 })
            {
                return Student.Enrollment[semesterIndex[0]];
            }
            else
            {
                return new Semester();
            }
        }
    }
}
