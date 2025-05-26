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

        public void AddCourse(Course course, Period period, List<Lecture> lectures)
        {
            if (period.Id == 0)
            {
                _db.Insert(period);
            }

            course.PeriodId = period.Id;

            _db.Insert(course);

            foreach (var lecture in lectures)
            {
                if (lecture.Id == 0)
                {
                    _db.Insert(lecture);
                }
                _db.Insert(new CourseLecture
                {
                    CourseId = course.Id,
                    LectureId = lecture.Id
                });
            }
        }

        public void UpdateCourse(Course course, Period period, List<Lecture> lectures)
        {
            _db.Update(course);

            _db.DeleteCourseLecture(course.Id);

            foreach (var lecture in lectures)
            {
                if (lecture.Id == 0)
                {
                    _db.Insert(lecture);
                }

                _db.Insert(new CourseLecture
                {
                    CourseId = course.Id,
                    LectureId = lecture.Id
                });
            }
        }

        public void DeleteCourse(int id)
        {
            _db.Delete<Course>(id);
        }

        public List<Course> SearchCourseByName(string name)
        {
            return _db.Search<Course>(name);
        }

        public Course GetFullCourse(int id)
        {
            var course = _db.SearchByQuery<Course>($"SELECT * FROM Course WHERE Id = {id}").FirstOrDefault();

            course.Period = _db.SearchByQuery<Period>($"SELECT * FROM Period WHERE Id = {course.PeriodId}").FirstOrDefault();

            course.Lectures = _db.SearchByQuery<Lecture>($"SELECT l.* FROM Lecture l " +
                                             $"JOIN CourseLecture cl ON l.Id = cl.LectureId " +
                                             $"WHERE cl.CourseId = {course.Id}");

            return course;
        }

        public List<Course> GetCoursesByLectureId(int lectureId)
        {
            string sql = $"SELECT c.* FROM Course c " +
                         $"JOIN CourseLecture cl ON c.Id = cl.CourseId " +
                         $"WHERE cl.LectureId = {lectureId}";
            return _db.SearchByQuery<Course>(sql);
        }

        public List<Course> GetCoursesByPeriodId(int periodId)
        {
            string sql = $"SELECT c.* FROM Course c " +
                         $"JOIN CourseLecture cl ON c.Id = cl.CourseId " +
                         $"JOIN Period p ON cl.PeriodId = p.Id " +
                         $"WHERE p.Id = {periodId}";
            return _db.SearchByQuery<Course>(sql);
        }
        
        public void AddLectureToCourse(int courseId, int lectureId)
        {
            var courseLecture = new CourseLecture
            {
                CourseId = courseId,
                LectureId = lectureId
            };

            _db.Insert(courseLecture);
        }
    }
}
