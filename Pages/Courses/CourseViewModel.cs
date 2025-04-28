using AcademiApp.Pages.Lectures;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Xml.Serialization;
using AcademiApp.Models;

namespace AcademiApp.Pages.Courses
{
    public class CourseViewModel
    {
        public required ObservableCollection<Course> Courses { get; set; }
        public ICommand ItemClickedCommand { get; }

        public CourseViewModel() 
        {
            ItemClickedCommand = new Command<Course>(OnItemClicked);
            Courses = new ObservableCollection<Course>();
        }

        public async void OnItemClicked(Course selectedCourse)
        {
            await Shell.Current.Navigation.PushAsync(new CourseInfoPage(selectedCourse));
        }
    }
}
