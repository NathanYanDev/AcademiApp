namespace AcademiApp.Pages.Courses;
using AcademiApp.Models;

public partial class EditCoursesPage : ContentPage
{
	private Course _editCourse;

	public Course EditCourse
	{
		get => _editCourse;
		set
		{
			_editCourse = value;
			OnPropertyChanged(nameof(EditCourse));
		}
	}

	public EditCoursesPage(Course course)
	{
		InitializeComponent();
		EditCourse = course;
		BindingContext = this;
	}
}