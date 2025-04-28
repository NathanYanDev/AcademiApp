using System.Collections.ObjectModel;
using AcademiApp.Models;
namespace AcademiApp.Pages.Courses;

public partial class ListCoursesPage : ContentPage
{
	ObservableCollection<Course> courses = new();

	public ListCoursesPage()
	{
		InitializeComponent();

		lstCourses.ItemsSource = courses;
	}

	private async void GoToAddCoursePage(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new AddCoursesPage());
	}
}