namespace AcademiApp.Pages.Courses;

public partial class ListCoursesPage : ContentPage
{
	public ListCoursesPage()
	{
		InitializeComponent();
	}

    private async void GoToAddCoursePage(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new AddCoursesPage());
    }
}