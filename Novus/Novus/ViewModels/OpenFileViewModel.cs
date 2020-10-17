using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Novus.ViewModels
{
    [QueryProperty("Name", "name")]
    class OpenFileViewModel : BaseViewModel
    {

        string name;
        public string Name
        {
            get => name;
            set
            {
                SetProperty(ref name, Uri.UnescapeDataString(value));
            }
        }

    }
}
