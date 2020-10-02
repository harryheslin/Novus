using MvvmHelpers;
using System;
using Novus.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Text;
using Telerik.XamarinForms.Input;

namespace Novus.ViewModels
{
    class EventsViewModel : BaseViewModel
    {
        public EventsViewModel()
        {
            Appointments = Events.Appointments;
        }

        public ObservableCollection<Appointment> Appointments { get; set; }
    }
}
