using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Novus.ViewModels
{
    [QueryProperty("Unit", "unit")]
    class UnitGradesViewModel : BaseViewModel
    {
        string unit;
        public string Unit
        {
            get => unit;
            set
            {
                SetProperty(ref unit, Uri.UnescapeDataString(value));
                OnPropertyChanged(nameof(unit));
            }
        }
    }
}
