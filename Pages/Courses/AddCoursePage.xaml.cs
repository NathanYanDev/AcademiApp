namespace AcademiApp.Pages.Courses;
using AcademiApp.Models;

public partial class AddCoursesPage : ContentPage
{

	public AddCoursesPage()
	{
		InitializeComponent();
	}

	private async void SaveChanges(object sender, EventArgs e)
	{
		try
		{
			Course course = new Course
			{
				Name = etrCourseName.Text,
				Code = etrCourseCode.Text,
				Description = editorCourseDesc.Text,
			};


		}
		catch (Exception ex)
		{
			await DisplayAlert("Erro", ex.Message, "OK");
		}
	}
}