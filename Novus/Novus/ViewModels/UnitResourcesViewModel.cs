using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Novus.ViewModels
{
    [QueryProperty("Unit", "unit")]
    [QueryProperty("Colour", "colour")]
    class UnitResourcesViewModel : BaseViewModel
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

        string colour;
        public string Colour
        {
            get => colour;
            set
            {
                SetProperty(ref colour, Uri.UnescapeDataString(value));
                OnPropertyChanged(nameof(colour));
            }
        }

    }
}
