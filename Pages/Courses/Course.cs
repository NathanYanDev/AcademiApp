using AcademiApp.Pages.Lectures;

namespace AcademiApp.Pages.Courses
{
    public class Course
    {
        public required string CourseName { get; set; }
        public required string CourseCode { get; set; }
        public required string CoursePeriod { get; set; }
        public string? CourseDescription { get; set; }
        public required List<Lecture> Lectures { get; set; }
    } 
}
