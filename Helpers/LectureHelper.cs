using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademiApp.Models;
using SQLite;

namespace AcademiApp.Helpers
{
    public class LectureHelper
    {
        readonly SQLiteDatabaseHelpers _db;

        public LectureHelper(SQLiteDatabaseHelpers db)
        {
            _db = db;
        }

        public List<Lecture> GetAllLectures()
        {
            return _db.GetAll<Lecture>();
        }

        public void AddLecture(Lecture lecture)
        {
            _db.Insert(lecture);
        }

        public void UpdateLecture(Lecture lecture)
        {
            _db.Update(lecture);
        }

        public void DeleteLecture(int id)
        {
            _db.Delete<Lecture>(id);
        }

        public List<Lecture> SearchLectureByName(string name)
        {
            return _db.Search<Lecture>(name);
        }

        public Lecture SearchById(int id)
        {
            return _db.GetById<Lecture>(id);
        }

        public List<Lecture> GetLecturesByCourseId(int courseId)
        {
            string sql = $"SELECT * FROM Lecture WHERE Id IN (SELECT LectureId FROM CourseLecture WHERE CourseId = {courseId})";
            return _db.SearchByQuery<Lecture>(sql);
        }
    }
}
