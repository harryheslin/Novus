using MvvmHelpers;
using System;
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
            Appointments = new ObservableCollection<Appointment>
            {
                new Appointment
                {
                    Title = "Yeet",
                    Detail = "Tis the Day",
                    StartDate = DateTime.Parse("21/09/2020"),
                    EndDate = DateTime.Parse("21/09/2020"),
                    Color = Color.Red,
                    IsAllDay = true
                }
            };
        }
        public ObservableCollection<Appointment> Appointments { get; set; }
    }
}
