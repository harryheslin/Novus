using Novus.Models;
using System;
using Xamarin.Forms;
using System.IO;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Novus.Data;

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

        static List<Unit> units;
        public static List<Unit> Units
        {
            get => units;
        }

        public App()
        {
            InitializeComponent();
            student = Database.GetStudent();
            units = Database.GetUnits();
            GenerateNewUnits();
            
            MainPage = new MainPage();
        }

        private void GenerateNewUnits()
        {
            bool isInCurrent = false;
            NewUnit.RemoveAllUnits();
            foreach (Unit valueOne in Datastore.AllUnits)
            {
                foreach (Semester valueTwo in student.Enrollment)
                {
                    foreach (Unit valueThree in valueTwo.EnrolledUnits)
                    {
                        if (valueThree.Code == valueOne.Code)
                        {
                            isInCurrent = true;
                            break;
                        }
                    }

                }

                if (isInCurrent)
                {
                    isInCurrent = false;
                }
                else
                {
                    NewUnit.AddUnit(valueOne);
                }
            }
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
