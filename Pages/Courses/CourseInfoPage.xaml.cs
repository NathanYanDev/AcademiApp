namespace AcademiApp.Pages.Courses;
using AcademiApp.Models;
using System.Collections.ObjectModel;

public partial class CourseInfoPage : ContentPage
{
    ObservableCollection<Lecture> lectures = new();
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
        lstLectures.ItemsSource = lectures;
        SelectedCourse = selectedCourse;
        BindingContext = this;
    }

    protected override void OnAppearing()
    {
        LoadLectures();
        LoadPeriod();
    }

    private void LoadPeriod()
    {
        lblPeriodName.Text = App.PeriodHelper.GetPeriodByID(_selectedCourse.PeriodId).Name;
    }

    private void LoadLectures()
    {
        var LectureList = App.LectureHelper.GetLecturesByCourseId(SelectedCourse.Id);

        lectures.Clear();

        foreach (Lecture lecture in LectureList)
        {
            lectures.Add(lecture);
        }
    }


    public async void EditCourseEvent(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EditCoursesPage(_selectedCourse));
    }

    private async void DeleteCourseEvent(object sender, EventArgs e)
    {
        try
        {
            bool confirmExclusion = await DisplayAlert("Confirmação", "Confirma a remoção?", "Sim", "Não");

            if(confirmExclusion)
            {
                App.CourseHelper.DeleteCourse(SelectedCourse.Id);

                await Shell.Current.GoToAsync("..");
            }

        } catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "OK");
        }
    }
}