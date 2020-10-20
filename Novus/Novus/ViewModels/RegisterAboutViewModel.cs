using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MvvmHelpers;
using Novus.Data;
using Novus.Models;

namespace Novus.ViewModels
{
    class RegisterAboutViewModel : BaseViewModel
    {
        public RegisterAboutViewModel()
        {
            course = Datastore.GetCourse();
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
