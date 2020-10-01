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

        Student TestStudent = Student.GenerateStudent(4);
        public string Unit1 => TestStudent.Enrollment[0].EnrolledUnits[0].Name;
        public string Unit2 => TestStudent.Enrollment[0].EnrolledUnits[1].Name;
        public string Unit3 => TestStudent.Enrollment[0].EnrolledUnits[2].Name;
        public string Unit4 => TestStudent.Enrollment[0].EnrolledUnits[3].Name;

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
            routes.Add("calendarWeek",typeof(CalendarWeek));
            routes.Add("eventAdd",typeof(EventAdd));
            

            foreach (var item in routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }
    }
}
