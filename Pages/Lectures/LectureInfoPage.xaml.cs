namespace AcademiApp.Pages.Lectures;
using AcademiApp.Models;
using System.Collections.ObjectModel;

public partial class LectureInfoPage : ContentPage
{
	private Lecture _selectedLecture;
    private ObservableCollection<Course> courses = new();

	public Lecture SelectedLecture
	{
		get => _selectedLecture;
        set
        {
            _selectedLecture = value;
            OnPropertyChanged();
        }
    }
    public LectureInfoPage(Lecture selectedLecture)
    {
        InitializeComponent();
        BindingContext = this;
        SelectedLecture = selectedLecture;
        lstCourses.ItemsSource = courses;
    }

    public LectureInfoPage()
	{
		InitializeComponent();
        lstCourses.ItemsSource = courses;
    }

    protected override void OnAppearing()
    {
        LoadCourses();
    }

    private void LoadCourses()
    {
        var courseList = App.CourseHelper.GetCoursesByLectureId(SelectedLecture.Id);

        courses.Clear();

        foreach (Course course in courseList)
        {
            courses.Add(course);
        }
    }

    private async void EditLectureEvent(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EditLecturePage(_selectedLecture));
    }

    private async void DeleteLectureEvent(object sender, EventArgs e)
    {
        try
        {
            bool confirmExclusion = await DisplayAlert("Confirmação", "Confirma a remoção?", "Sim", "Não");
            if (confirmExclusion)
            {
                App.LectureHelper.DeleteLecture(SelectedLecture.Id);
                await Shell.Current.GoToAsync("..");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "OK");
        }
    }
}