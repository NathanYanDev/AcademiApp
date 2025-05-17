using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using AcademiApp.Models;

namespace AcademiApp.Helpers
{
    public class SQLiteDatabaseHelpers
    {
        readonly SQLiteAsyncConnection _conn;
        public SQLiteDatabaseHelpers(string dbPath)
        {
            _conn = new SQLiteAsyncConnection(dbPath);

            _conn.CreateTableAsync<Course>().Wait();
            _conn.CreateTableAsync<Lecture>().Wait();
            _conn.CreateTableAsync<Period>().Wait();
            _conn.CreateTableAsync<CourseLecture>().Wait();
        }

        public int Insert<T>(T item)
        {
            return _conn.InsertAsync(item).Result;
        }

        public int Update<T>(T item)
        {
            return _conn.UpdateAsync(item).Result;
        }

        public int Delete<T>(int id)
        {
            return _conn.DeleteAsync<T>(id).Result;
        }

        public List<T> GetAll<T>() where T : new()
        {
            return _conn.Table<T>().ToListAsync().Result;
        }

        public List<T> Search<T>(string name) where T : new()
        {
            string sql = $"SELECT * FROM {typeof(T).Name} WHERE Name LIKE '%{name}%'";
            return _conn.QueryAsync<T>(sql).Result;
        }
    }
}
