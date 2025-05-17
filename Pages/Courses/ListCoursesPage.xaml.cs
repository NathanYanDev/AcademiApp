using System.Collections.ObjectModel;
using System.Windows.Input;
using AcademiApp.Models;
namespace AcademiApp.Pages.Courses;

public partial class ListCoursesPage : ContentPage
{
	ObservableCollection<Course> courses = new();

	public ICommand ItemClickedCommand { get; }

	public ListCoursesPage()
	{
		InitializeComponent();

		lstCourses.ItemsSource = courses;

		ItemClickedCommand = new Command<Course>(OnItemClicked);
	}

	public async void OnItemClicked(Course selectedCourse)
	{
		await Shell.Current.Navigation.PushAsync(new CourseInfoPage(selectedCourse));
	}

	private async void GoToAddCoursePage(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new AddCoursesPage());
	}

	protected override void OnAppearing()
    {
        LoadCourses();
    }

    private void LoadCourses()
    {
        var courseList = App.CourseHelper.GetAllCourses();

        courses.Clear();

        foreach (Course course in courseList)
        {
            courses.Add(course);
        }
    }

    private void searchCourse(object sender, TextChangedEventArgs e)
	{
        string query = e.NewTextValue;

        courses.Clear();

		List<Course> courseList = App.CourseHelper.SearchCourseByName(query);

		foreach (Course course in courseList)
		{
			courses.Add(course);
		}
	}
}