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

	private async void SaveEditedChanges(object sender, EventArgs e)
	{
		try
		{
			Course course = new Course();

            course.Id = EditCourse.Id;
            course.Name = etrCourseName.Text;
			course.Code = etrCourseCode.Text;
			course.Description = editorCourseDescription.Text;

			if (string.IsNullOrEmpty(course.Name) || string.IsNullOrEmpty(course.Code) || string.IsNullOrEmpty(course.Description))
			{
				await DisplayAlert("Erro", "Por favor preencha todos os campos", "OK");
			}
			else
			{
				App.CourseHelper.UpdateCourse(course);

				await DisplayAlert("Sucesso", "Curso atualizado com sucesso", "OK");

				await Shell.Current.GoToAsync("../..");
			}

        }
		catch (Exception ex) 
		{
            await DisplayAlert("Erro", ex.Message, "OK");
        }
	}

	private async void ReturnPage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}