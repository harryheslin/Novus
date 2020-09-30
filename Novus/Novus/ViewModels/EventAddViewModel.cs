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
        public EventAddViewModel()
        {
            var date = DateTime.Today;
            this.Appointments = new ObservableCollection<Appointment>
            {
            new Appointment {
                    Title = "Meeting with Tom",
                    Detail = "Sea Garden",
                    StartDate = DateTime.Parse("23/12/2020").AddHours(0),
                    EndDate = DateTime.Parse("23/12/2020").AddHours(0),
                    Color = Color.Tomato,   
                    IsAllDay=true
                },
                new Appointment {
                    Title = "Lunch with Sara",
                    Detail = "Restaurant",
                    StartDate = date,
                    EndDate = date.AddHours(14),
                    Color = Color.DarkTurquoise
                },
                new Appointment {
                    Title = "Elle Birthday",
                    StartDate = date,
                    EndDate = date.AddHours(11),
                    Color = Color.Orange,
                    IsAllDay = true
                },
                 new Appointment {
                    Title = "Football Game",
                    StartDate = date.AddDays(2).AddHours(15),
                    EndDate = date.AddDays(2).AddHours(17),
                    Color = Color.Green
                }
            };
        }
        public ObservableCollection<Appointment> Appointments { get; set; }
    }
}
