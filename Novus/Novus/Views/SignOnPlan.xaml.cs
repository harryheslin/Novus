using Novus.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Novus.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignOnPlan : ContentPage
    {
        public SignOnPlan()
        {
            InitializeComponent();
        }

        private void ExpandUnit(object sender, EventArgs e)
        {
            var viewModel = BindingContext as SignOnPlanViewModel;
            viewModel?.SetIsVisible((int)((TappedEventArgs)e).Parameter);
        }

        private void Plan(object sender, EventArgs e)
        {
            var viewModel = BindingContext as SignOnPlanViewModel;
            CheckBox checkBox = (CheckBox)sender;
            viewModel?.PlanForClass(checkBox.AutomationId);
        }
    }
}