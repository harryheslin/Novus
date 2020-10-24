using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Telerik.XamarinForms.Common;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Essentials;
using Novus.Data;
using SQLiteNetExtensions.Extensions;
using System.Collections.ObjectModel;

namespace Novus.Models
{
    class Database
    {
        readonly SQLiteConnection database;

        public Database(string dbPath)
        {
            database = new SQLiteConnection(dbPath);

            database.CreateTable<EventsDB>();
            database.CreateTable<AnnouncementDB>();
            database.CreateTable<AssesmentDB>();
            database.CreateTable<ClassDB>();
            database.CreateTable<ResourcesDB>();
            database.CreateTable<UnitDB>();

            if(database.Table<UnitDB>().ToList().Count == 0)
            {
                ObservableCollection<Unit> units = Datastore.GenerateAllUnits();
                foreach(Unit unit in units)
                {
                    SaveUnit(unit);
                }
            }

            database.CreateTable<SemesterDB>();
            database.CreateTable<StudentDB>();

            if (database.Table<StudentDB>().ToList().Count == 0)
            {
                List<Unit> units = GetUnits();
                Student student = Datastore.GetStudent();
                SaveStudent(student);
            }

        }

        public List<Unit> GetUnits()
        {
            List<UnitDB> values = database.GetAllWithChildren<UnitDB>();
            List<Unit> returnValue = new List<Unit>();

            foreach(UnitDB value in values)
            {
                returnValue.Add(value.ConvertToModel());
            }

            return returnValue;
        }

        public void SaveUnit(Unit unit)
        {
            database.InsertWithChildren(unit.ConvertToDB(), recursive: true);
        }

        public void UpdateUnit(Unit unit)
        {
            database.UpdateWithChildren(unit.ConvertToDB());
        }

        public Student GetStudent()
        {
            List<StudentDB> students = database.GetAllWithChildren<StudentDB>(recursive: true);
            return students.First().ConvertToModel();
        }

        public void SaveStudent(Student student)
        {
            database.InsertWithChildren(student.ConvertToDB(), recursive: true);
        }

        public void UpdateStudent(Student student)
        {
            database.UpdateWithChildren(student.ConvertToDB());
        }

        public void UpdateClass(Class classs)
        {
            database.UpdateWithChildren(classs.ConvertToDB());
        }
    }
}
