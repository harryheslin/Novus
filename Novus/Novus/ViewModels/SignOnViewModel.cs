using MvvmHelpers;
using Novus.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Novus.ViewModels
{
    class SignOnViewModel : BaseViewModel
    {

        public Command CalanderButton { get; }

        public SignOnViewModel()
        {
            student = App.Student;
            CalanderButton = new Command(GoToCalander);
        }

        async void GoToCalander()
        {
            await Shell.Current.GoToAsync("signOnCalander");
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

        public ObservableCollection<Unit> Units
        {
            get => Student.CurrentUnits;
        }

        public void SetIsVisible(int unitID)
        { 
            Unit unit = GetUnit(unitID);
            if (unit.UnitID != -1)
            {
                if(unit.IsVisible)
                {
                    unit.IsVisible = false;
                } else
                {
                    unit.IsVisible = true;
                }

                SetUnitValue(unit);
            }
        }

        public void RegisterForClass(string tag)
        {
            try
            {
                Class classs = GetClass(int.Parse(tag));
                if (classs.ClassID != -1)
                {
                    Student newStudent = student;
                    newStudent.EnrollInClass(classs, classs.UnitID);

                    foreach(Unit unit in newStudent.CurrentUnits)
                    {
                        if(unit.UnitID == classs.UnitID)
                        {
                            SetUnitValue(unit);
                        }
                    }
                }
            } 
            catch
            {

            }
            
        }

        private Class GetClass(int classID)
        {
            foreach(Unit unit in Units)
            {
                int classIndex = Class.GetClassIndex(unit.Lectures, classID);
                if(classIndex != -1)
                {
                    return Student.CurrentUnits[Unit.GetUnitIndex(Student.CurrentUnits, unit.UnitID)].Lectures[classIndex];
                }
                classIndex = Class.GetClassIndex(unit.Tutorials, classID);
                if(classIndex != -1)
                {
                    return Student.CurrentUnits[Unit.GetUnitIndex(Student.CurrentUnits, unit.UnitID)].Tutorials[classIndex];
                }
            }
            return new Class();
        }

        private void SetUnitValue(Unit newValue)
        {
                int index = Unit.GetUnitIndex(student.CurrentUnits, newValue.UnitID);
                Student.CurrentUnits[index] = newValue;
        }

        private Unit GetUnit(int indexingUnitID)
        {
            int index = Unit.GetUnitIndex(Student.CurrentUnits, indexingUnitID);
            if (index != -1)
            {
                return Student.CurrentUnits[index];
            }

            return new Unit();
        }
    }
}
