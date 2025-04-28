namespace AcademiApp.Pages.Courses;
using AcademiApp.Models;

public partial class CourseInfoPage : ContentPage
{
    private Course _selectedCourse;

    public Course SelectedCourse
    {
        get => _selectedCourse;
        set
        {
            _selectedCourse = value;
            OnPropertyChanged(nameof(SelectedCourse));
        }
    }

    public CourseInfoPage(Course selectedCourse)
    {
        InitializeComponent();
        SelectedCourse = selectedCourse;
        BindingContext = this;
    }

    public async void EditCourseEvent(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EditCoursesPage(_selectedCourse));
    }
}