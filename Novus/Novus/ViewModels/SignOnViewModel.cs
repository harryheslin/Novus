using MvvmHelpers;
using Novus.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novus.ViewModels
{
    class SignOnViewModel : BaseViewModel
    {
        public SignOnViewModel()
        {
            units = Unit.GenerateUnits(0);
        }

        Unit[] units;
        public Unit[] Units
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
