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

			if(string.IsNullOrWhiteSpace(etrCourseName.Text))
            {
                await DisplayAlert("Erro", "O campo Nome é obrigatório!", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(etrCourseCode.Text))
            {
                await DisplayAlert("Erro", "O campo Código é obrigatório!", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(editorCourseDesc.Text))
            {
                await DisplayAlert("Erro", "O campo Descrição é obrigatório!", "OK");
                return;
            }

            Course course = new Course
			{
				Name = etrCourseName.Text,
				Code = etrCourseCode.Text,
				Description = editorCourseDesc.Text,
			};

			App.CourseHelper.AddCourse(course);

			await DisplayAlert("Sucesso", "Registro inserido com sucesso!", "OK");

			await Navigation.PushAsync(new ListCoursesPage());
        }
		catch (Exception ex)
		{
			await DisplayAlert("Erro", ex.Message, "OK");
		}
	}
}