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
                    StartDate = DateTime.Parse("23/12/2020 00:00:00"),
                    EndDate = DateTime.Parse("23/12/2020 01:00:00"),
                    Color = eventColour("Green"),
                    IsAllDay = false
                }
            };
        }
        public ObservableCollection<Appointment> Appointments { get; set; }
    }
}
