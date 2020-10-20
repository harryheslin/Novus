using Novus.Models;
using Novus.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public void ExpandUnit(object sender, EventArgs e)
        {
            var viewModel = BindingContext as RegisterViewModel;
            viewModel?.SetIsVisibleUnit((int)((TappedEventArgs)e).Parameter);
        }

        public void RemoveUnit(object sender, EventArgs e)
        {
            var viewModel = BindingContext as RegisterViewModel;
            viewModel?.RemoveUnit((int)((TappedEventArgs)e).Parameter);
        }

        public void AddUnit(object sender, EventArgs e)
        {
            var viewModel = BindingContext as RegisterViewModel;
            viewModel?.AddUnit((Unit)((TappedEventArgs)e).Parameter);
        }

        public void ExpandNewUnit(object sender, EventArgs e)
        {
            var viewModel = BindingContext as RegisterViewModel;
            viewModel?.SetIsVisiableNewUnit((int)((TappedEventArgs)e).Parameter);
        }

        public void ExpandNewUnitsUnit(object sender, EventArgs e)
        {
            var viewModel = BindingContext as RegisterViewModel;
            viewModel?.SetIsVisibleNewUnitsUnit((string)((TappedEventArgs)e).Parameter);
        }
    }
}