using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using AcademiApp.Models;

namespace AcademiApp.Helpers
{
    public class CourseHelper
    {
        private readonly SQLiteDatabaseHelpers _db;

        public CourseHelper(SQLiteDatabaseHelpers db)
        {
            _db = db;
        }

        public List<Course> GetAllCourses()
        {
            return _db.GetAll<Course>();
        }

        public void AddCourse(Course course)
        {
            _db.Insert(course);
        }

        public void UpdateCourse(Course course)
        {
            _db.Update(course);
        }

        public void DeleteCourse(int id)
        {
            _db.Delete<Course>(id);
        }

        public List<Course> SearchCourseByName(string name)
        {
            return _db.Search<Course>(name);
        }
    }
}
