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

namespace Novus.Models
{
    class Database
    {
        readonly SQLiteConnection database;

        public Database(string dbPath)
        {
            database = new SQLiteConnection(dbPath);

            database.DropTable<AnnouncementDB>();
            database.DropTable<EventsDB>();
            database.DropTable<AssesmentDB>();
            database.DropTable<ClassDB>();
            database.DropTable<ResourcesDB>();
            database.DropTable<UnitDB>();
            database.DropTable<SemesterDB>();
            database.DropTable<StudentDB>();

            database.CreateTable<EventsDB>();
            database.CreateTable<AnnouncementDB>();
            database.CreateTable<AssesmentDB>();
            database.CreateTable<ClassDB>();
            database.CreateTable<ResourcesDB>();
            database.CreateTable<UnitDB>();

            if(database.Table<UnitDB>().ToList().Count == 0)
            {
                List<Unit> units = Datastore.GenerateAllUnits();
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
            return database.GetAllWithChildren<StudentDB>(recursive: true).First().ConvertToModel();
        }

        public void SaveStudent(Student student)
        {
            database.InsertWithChildren(student.ConvertToDB(), recursive: true);
        }

        public void UpdateStudent(Student student)
        {
            database.UpdateWithChildren(student.ConvertToDB());
        }
    }
}
