using AcademiApp.Pages.Courses;
namespace AcademiApp.Pages.Lectures
{
    public class Lecture
    {
        public required string LectureName { get; set; }
        public required string LectureCode { get; set; }
        public required string LectureDescription { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();
    }
}
