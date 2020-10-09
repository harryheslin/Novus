using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Telerik.XamarinForms.Common;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Essentials;

namespace Novus.Models
{
    class Database
    {
        readonly SQLiteConnection database;

        public Database(string dbPath)
        {
            database = new SQLiteConnection(dbPath);

            database.CreateTable<Information>();
            database.CreateTable<Announcement>();
            database.CreateTable<Assesment>();
            database.CreateTable<Class>();
            database.CreateTable<Major>();
            database.CreateTable<Minor>();
            database.CreateTable<Course>();
            database.CreateTable<Resources>();
            database.CreateTable<Unit>();
            database.CreateTable<Semester>();
            database.CreateTable<Student>();
        }

        public ObservableItemCollection<Unit> GetUnits()
        {
            List <Unit> values = database.Table<Unit>().ToList();
            ObservableItemCollection<Unit> returnValue = new ObservableItemCollection<Unit>();
            foreach(Unit value in values)
            {
                returnValue.Add(value);
            }

            return returnValue;
        }

        public void SaveUnit(Unit unit)
        {
            database.Insert(unit);
        }

        public void UpdateUnit(Unit unit)
        {
            database.Update(unit);
        }

        public Student GetStudent()
        {
            return database.Table<Student>().ToList().First();
        }

        public void SaveStudent(Student student)
        {
            database.Insert(student);
        }

        public void UpdateStudent(Student student)
        {
            database.Update(student);
        }

    }
}
