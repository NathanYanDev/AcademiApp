namespace AcademiApp;
using AcademiApp.Pages;
using AcademiApp.Pages.Lectures;
using AcademiApp.Pages.Courses;
using AcademiApp.Pages.Periods;


public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        Application.Current.UserAppTheme = AppTheme.Light;
    }

    public async void btnNavCourses_Clicked(Object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//ListCoursesPage");
    }

    public async void btnNavClasses_Clicked(Object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//ListClassesPage");
    }

    public async void btnNavPeriods_Clicked(Object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//ListPeriodsPage");
    }

    public async void btnNavAbout_Clicked(Object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//AboutPage");
    }
}
