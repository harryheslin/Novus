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
        
        public string NameInput { set; get; }
        public string DescriptionInput { set; get; }
        public Command AddEventButton { get; }
        public DateTime StartDateSelected { get; set; }
        public DateTime EndDateSelected { get; set; }
        public string ColourSelected { get; set; }
        public bool AllDayToggle { set; get; }


        public DateTime Today { get; private set; }

        public EventAddViewModel()
        {
            AddEventButton = new Command(AddEventAndGoBack);
            Today = DateTime.Now;
        }

        async void AddEventAndGoBack()
        {
            await Shell.Current.Navigation.PopAsync();
        }
    }
}
