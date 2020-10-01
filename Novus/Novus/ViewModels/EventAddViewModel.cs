using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MvvmHelpers;
using Telerik.XamarinForms.Input;
using Xamarin.Forms;

namespace Novus.ViewModels
{
    class EventAddViewModel : BaseViewModel
    {                              
        public bool AllDayToggle { set; get; }
        public string NameInput { set; get; }
        public Command AddEventButton { get; }
        public string ColourSelected { get; set; }
        public DateTime StartDateSelected { get; set; }
        public DateTime EndDateSelected { get; set; }

        public EventAddViewModel()
        {
            AddEventButton = new Command(AddEventAndGoBack);
        }

        async void AddEventAndGoBack()
        {
            await Shell.Current.Navigation.PopAsync();
        }
    }
}
