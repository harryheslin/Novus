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
    public partial class UnitPage : ContentPage
    {
        public UnitPage()
        {
            InitializeComponent();
        }
        public async void Resources_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UnitResources());
        }
        public async void Assesment_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UnitAssesment());
        }
        public async void Announcements_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UnitAnnouncements());
        }
        public async void Grades_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UnitGrades());
        }
    }
}