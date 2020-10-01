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
        public Color eventColour(string colour)
        {
            if (colour == "Green")
            {
                return Color.Green;
            }
            else
            {
                return Color.Beige;
            }
        }
        public EventsViewModel()
        {
            Appointments = new ObservableCollection<Appointment>
            {
                new Appointment
                {
                    Title = "Yeet",
                    Detail = "Tis the Day",
                    StartDate = DateTime.Parse("2/10/2020"),
                    EndDate = DateTime.Parse("2/10/2020"),
                    Color = eventColour("Green"),
                    IsAllDay = true
                }
            };
        }
        public ObservableCollection<Appointment> Appointments { get; set; }
    }
}
