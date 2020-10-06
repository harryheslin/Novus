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
    public partial class UnitResources : ContentPage
    {
        public UnitResources()
        {
            InitializeComponent();
        }

        private void ExpandUnit(object sender, EventArgs e)
        {
            var viewModel = BindingContext as UnitResourcesViewModel;
            viewModel?.SetIsVisible((string)((TappedEventArgs)e).Parameter);
        }
    }
}