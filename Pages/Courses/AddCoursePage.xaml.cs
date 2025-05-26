namespace AcademiApp.Pages.Courses;
using AcademiApp.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

public partial class AddCoursesPage : ContentPage
{
	ObservableCollection<Period> periods = new();

    ObservableCollection<Lecture> lectures = new();
    ObservableCollection<Lecture> selectedLectures = new();

    public AddCoursesPage()
	{
		InitializeComponent();

		pckPeriod.ItemsSource = periods;

        lecturesCollection.ItemsSource = lectures;

        lecturesCollection.SelectionChanged += (s, e) =>
        {
            selectedLectures.Clear();
            foreach (var item in lecturesCollection.SelectedItems)
            {
                if (item is Lecture lecture)
                {
                    selectedLectures.Add(lecture);
                }
            }
        };
    }

	protected override void OnAppearing()
    {
        LoadPeriods();
        LoadLectures();
    }

    private void LoadLectures()
    {
        var lectureList = App.LectureHelper.GetAllLectures();

        lectures.Clear();

        foreach (Lecture lecture in lectureList)
        {
            lectures.Add(lecture);
        }
    }

    private void LoadPeriods()
    {
        var periodList = App.PeriodHelper.GetAllPeriods();

        periods.Clear();

        foreach (Period period in periodList)
        {
            periods.Add(period);
        }
    }

    private async void SaveChanges(object sender, EventArgs e)
	{
        try
        {

            if (string.IsNullOrWhiteSpace(etrCourseName.Text))
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

            if (!(pckPeriod.SelectedItem is Period selectedPeriod))
            {
                await DisplayAlert("Erro", "Selecione um período válido!", "OK");
                return;
            }

            var selectedLecturesList = selectedLectures?.Cast<Lecture>().ToList();

            if (selectedLecturesList == null || !selectedLecturesList.Any())
            {
                await DisplayAlert("Erro", "Selecione pelo menos uma disciplina!", "OK");
                return;
            }

            Course course = new Course
            {
                Name = etrCourseName.Text,
                Code = etrCourseCode.Text,
                Description = editorCourseDesc.Text
            };

            App.CourseHelper.AddCourse(course, selectedPeriod, selectedLecturesList);

            await DisplayAlert("Sucesso", "Registro inserido com sucesso!", "OK");

			await Navigation.PushAsync(new ListCoursesPage());
        }
		catch (Exception ex)
		{
			await DisplayAlert("Erro", ex.Message, "OK");
		}
	}
}