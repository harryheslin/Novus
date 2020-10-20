using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Novus.ViewModels
{
    class SignOnMainViewModel : BaseViewModel
    {
        public Command SignOnButton { get; }
        public Command PlanButton { get; }

        public SignOnMainViewModel()
        {
            SignOnButton = new Command(GoToSignOn);
            PlanButton = new Command(GoToPlan);
        }

        async void GoToSignOn()
        {
            await Shell.Current.GoToAsync("signOn");
        }

        async void GoToPlan()
        {
            await Shell.Current.GoToAsync("signOnPlan");
        }
    }
}
