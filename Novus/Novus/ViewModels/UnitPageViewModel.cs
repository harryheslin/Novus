using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Essentials;
using MvvmHelpers;
namespace Novus.ViewModels
{
    class UnitPageViewModel : BaseViewModel
    {
        public UnitPageViewModel()
        {
            ChangeUnit = new Command(NextUnit);
        }

        string[] units = { "IAB330", "CAB432", "CAB303"};
        int unitIndex = 0;
        public string UnitName => units[unitIndex];

       public Command ChangeUnit { get; }

        void NextUnit()
        {
            if (unitIndex < 2)
            {
                unitIndex++;
            }
            else
            {
                unitIndex = 0;
            }
            OnPropertyChanged(nameof(UnitName));
        }
    }
}
