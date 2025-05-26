namespace AcademiApp.Pages.Courses;
using AcademiApp.Models;
using System.Collections.ObjectModel;

public partial class EditCoursesPage : ContentPage
{
    ObservableCollection<Period> periods = new();

    ObservableCollection<Lecture> lectures = new();
    ObservableCollection<Lecture> selectedLectures = new();
    private Course _editCourse;

	public Course EditCourse
	{
		get => _editCourse;
		set
		{
			_editCourse = value;
			OnPropertyChanged(nameof(EditCourse));
		}
	}

	public EditCoursesPage(Course course)
	{
		InitializeComponent();

        EditCourse = course;

        pckCoursePeriod.ItemsSource = periods;
        LoadPeriods();

		lecturesCollection.ItemsSource = lectures;
		LoadLectures();

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

		BindingContext = this;
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

	private void LoadLectures()
	{
		var lectureList = App.LectureHelper.GetAllLectures();

		lectures.Clear();

		foreach(Lecture lecture in lectureList)
		{
			lectures.Add(lecture);
		}
	}

    private async void SaveEditedChanges(object sender, EventArgs e)
	{
		try
		{
			Course course = new Course();

			course.Id = EditCourse.Id;
			course.Name = etrCourseName.Text;
			course.Code = etrCourseCode.Text;
			course.Description = editorCourseDescription.Text;

            if (!(pckCoursePeriod.SelectedItem is Period selectedPeriod))
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

            if (string.IsNullOrEmpty(course.Name) || string.IsNullOrEmpty(course.Code) || string.IsNullOrEmpty(course.Description))
			{
				await DisplayAlert("Erro", "Por favor preencha todos os campos", "OK");
			}
			else
			{
				course.Period = selectedPeriod;
                

				App.CourseHelper.UpdateCourse(course, selectedPeriod, selectedLecturesList);

				await DisplayAlert("Sucesso", "Curso atualizado com sucesso", "OK");

				await Shell.Current.GoToAsync("../..");
			}

        }
		catch (Exception ex) 
		{
            await DisplayAlert("Erro", ex.Message, "OK");
        }
	}

	private async void ReturnPage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}