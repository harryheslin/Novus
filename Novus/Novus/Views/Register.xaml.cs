using Novus.Models;
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
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
        }

        private void ExpandUnit(object sender, EventArgs e)
        {
            var viewModel = BindingContext as RegisterViewModel;
            viewModel?.SetIsVisible((int)((TappedEventArgs)e).Parameter);
        }

        private void RemoveUnit(object sender, EventArgs e)
        {
            var viewModel = BindingContext as RegisterViewModel;
            viewModel?.RemoveUnit((int)((TappedEventArgs)e).Parameter);
        }

        private void AddUnit(object sender, EventArgs e)
        {
            var viewModel = BindingContext as RegisterViewModel;
            viewModel?.AddUnit((int[])((TappedEventArgs)e).Parameter);
        }
    }
}