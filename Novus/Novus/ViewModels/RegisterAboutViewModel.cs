using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MvvmHelpers;
using Novus.Models;

namespace Novus.ViewModels
{
    class RegisterAboutViewModel : BaseViewModel
    {
        public RegisterAboutViewModel()
        {
            course = Models.Course.GenerateCourse();
        }

        ObservableCollection<Course> course;
        public ObservableCollection<Course> Course
        {
            get => course;
            set
            {
                SetProperty(ref course, value);
                OnPropertyChanged(nameof(Course));
            }
        }
    }
}
