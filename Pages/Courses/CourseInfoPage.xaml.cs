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