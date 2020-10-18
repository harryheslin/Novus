using MvvmHelpers;
using Novus.Models;
using System.Collections.ObjectModel;
using Telerik.XamarinForms.Input;

namespace Novus.ViewModels
{
    class EventsViewModel : BaseViewModel
    {
        Student student = App.Student;
        public EventsViewModel()
        {
            this.Appointments = new ObservableCollection<Appointment>();
            for (int i = 0; i < student.Events.Count; i++)
            {
                Appointments.Add(new Appointment
                {
                    Title = student.Events[i].EventName,
                    Detail = student.Events[i].EventDescription,
                    StartDate = student.Events[i].StartDate,
                    EndDate=student.Events[i].EndDate,
                    Color=Events.ColourDeterminer(student.Events[i].EventColour),
                    IsAllDay =student.Events[i].IsAllDay
                });
            }
            
        }

        ObservableCollection<Appointment> appointments;
        public ObservableCollection<Appointment> Appointments
        {
            get => appointments;
            set
            {
                SetProperty(ref appointments, value);
                OnPropertyChanged(nameof(Appointments));
            }
        }
    }
}
