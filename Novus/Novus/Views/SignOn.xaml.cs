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
    public partial class SignOn : ContentPage
    {
        public SignOn()
        {
            InitializeComponent();
        }

        private void ExpandUnit(object sender, EventArgs e)
        {
            var viewModel = BindingContext as SignOnViewModel;
            viewModel?.SetIsVisible((int)((TappedEventArgs)e).Parameter);
        }

        private void Register(object sender, EventArgs e)
        {
            var viewModel = BindingContext as SignOnViewModel;
            CheckBox checkBox = (CheckBox)sender;
            viewModel?.RegisterForClass(checkBox.AutomationId);
        }
    }
}