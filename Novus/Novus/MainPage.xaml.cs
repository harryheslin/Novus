using Novus.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Novus
{
    public partial class MainPage : Shell
    {

        Dictionary<string, Type> routes = new Dictionary<string, Type>();
        public Dictionary<string, Type> Routes { get { return routes; } }
        public MainPage()
        {
            InitializeComponent();
            RegisterRoutes();
            BindingContext = this;
        }

        void RegisterRoutes()
        {
            routes.Add("unit1", typeof(UnitPage));
            routes.Add("unit2", typeof(UnitPage));
            routes.Add("unit3", typeof(UnitPage));
            routes.Add("unit4", typeof(UnitPage));
            routes.Add("calendar", typeof(Calendar));
            routes.Add("resources", typeof(UnitResources));
            routes.Add("assesment", typeof(UnitAssesment));
            routes.Add("announcements", typeof(UnitAnnouncements));
            routes.Add("grades", typeof(UnitGrades));
            routes.Add("calendarDay", typeof(CalendarDay));

            foreach (var item in routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }
    }
}
