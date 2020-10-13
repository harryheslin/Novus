using MvvmHelpers;
using Novus.Models;
using System.Collections.ObjectModel;
using Telerik.XamarinForms.Input;

namespace Novus.ViewModels
{
    class EventsViewModel : BaseViewModel
    {
        public EventsViewModel()
        {
            Appointments = Events.Appointments;
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
