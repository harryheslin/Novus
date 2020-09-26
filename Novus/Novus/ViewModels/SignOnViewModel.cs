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
            units = Unit.GenerateUnits();
        }

        ObservableCollection<Unit> units;
        public ObservableCollection<Unit> Units
        {
            get => units;
            set
            {
                SetProperty(ref units, value);
                OnPropertyChanged(nameof(Student));
            }
        }
    }
}
