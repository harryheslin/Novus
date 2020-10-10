using Novus.Models;
using System;
using Xamarin.Forms;
using System.IO;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Novus
{
    public partial class App : Application
    {
        static Database database;
        static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Novus.db3"));
                }
                return database;
            }
        }

        static Student student;
        public static Student Student
        {
            get => student;
            set
            {
                database.UpdateStudent(value);
                student = database.GetStudent();
            }
        }

        private List<Unit> units;
        public List<Unit> Units
        {
            get => units;
        }

        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
            student = Database.GetStudent();
            units = Database.GetUnits();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
