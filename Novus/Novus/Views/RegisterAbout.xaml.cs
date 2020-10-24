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
    public partial class RegisterAbout : ContentPage
    {
        public RegisterAbout()
        {
            InitializeComponent();
        }

        private void GeneralTapped(object sender, EventArgs e)
        {
            var viewModel = BindingContext as RegisterAboutViewModel;
            viewModel?.SetIsVisibleGeneral();
        }

        private void MajorTapped(object sender, EventArgs e)
        {
            var viewModel = BindingContext as RegisterAboutViewModel;
            viewModel?.SetIsVisibleMajor();
        }

        private void MajorUnitsTapped(object sender, EventArgs e)
        {
            var viewModel = BindingContext as RegisterAboutViewModel;
            viewModel?.SetIsVisibleMajorUnits((int)((TappedEventArgs)e).Parameter);
        }

        private void MajorUnitTapped(object sender, EventArgs e)
        {
            var viewModel = BindingContext as RegisterAboutViewModel;
            viewModel?.SetIsVisibleMajorUnit((int)((TappedEventArgs)e).Parameter);
        }

        private void MinorTapped(object sender, EventArgs e)
        {
            var viewModel = BindingContext as RegisterAboutViewModel;
            viewModel?.SetIsVisibleMinor();
        }

        private void MinorUnitsTapped(object sender, EventArgs e)
        {
            var viewModel = BindingContext as RegisterAboutViewModel;
            viewModel?.SetIsVisibleMinorUnits((int)((TappedEventArgs)e).Parameter);
        }

        private void MinorUnitTapped(object sender, EventArgs e)
        {
            var viewModel = BindingContext as RegisterAboutViewModel;
            viewModel?.SetIsVisibleMinorUnit((int)((TappedEventArgs)e).Parameter);
        }
    }
}