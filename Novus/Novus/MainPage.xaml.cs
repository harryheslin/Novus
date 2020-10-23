using Novus.Models;
using Novus.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MvvmHelpers;

namespace Novus
{
    public partial class MainPage : Shell
    {

        Dictionary<string, Type> routes = new Dictionary<string, Type>();
        public Dictionary<string, Type> Routes { get { return routes; } }

        Student TestStudent = App.Student;
        public string Unit1 => TestStudent.CurrentUnits[1].Name;
        public string Unit2 => TestStudent.CurrentUnits[1].Name;
        public string Unit3 => TestStudent.CurrentUnits[2].Name;
        public string Unit4 => TestStudent.CurrentUnits[3].Name;

        public MainPage()
        {
            InitializeComponent();
            RegisterRoutes();
            BindingContext = this;
        }

        void RegisterRoutes()
        {
            routes.Add("homepage", typeof(Homepage));
            routes.Add("myUnitsPage", typeof(MyUnitsPage));
            routes.Add("unit", typeof(UnitPage));
            //routes.Add("unit2", typeof(UnitPage));
            //routes.Add("unit3", typeof(UnitPage));
            //routes.Add("unit4", typeof(UnitPage));
            routes.Add("calendar", typeof(Calendar));
            routes.Add("resources", typeof(UnitResources));
            routes.Add("assesment", typeof(UnitAssesment));
            routes.Add("announcements", typeof(UnitAnnouncements));
            routes.Add("grades", typeof(UnitGrades));
            routes.Add("calendarDay", typeof(CalendarDay));
            routes.Add("calendarWeek", typeof(CalendarWeek));
            routes.Add("eventAdd", typeof(EventAdd));
            routes.Add("calendarHome", typeof(CalendarHome));
            routes.Add("file", typeof(OpenFile));
            routes.Add("signOn", typeof(SignOn));
            routes.Add("signOnPlan", typeof(SignOnPlan));
            routes.Add("signOnMain", typeof(SignOnMain));
            routes.Add("registerAbout", typeof(RegisterAbout));
            routes.Add("register", typeof(Register));
            routes.Add("signOnCalander", typeof(SignOnCalander));
            routes.Add("planCalander", typeof(PlanCalander));



            foreach (var item in routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }
    }
}
