using AcademiApp.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AcademiApp.Pages.Lectures;

public partial class ListLecturesPage : ContentPage
{
	ObservableCollection<Lecture> lectures = new();

    public ICommand ItemClickedCommand { get; }


    public ListLecturesPage()
	{
		InitializeComponent();

		lstLectures.ItemsSource = lectures;

        ItemClickedCommand = new Command<Lecture>(OnItemClicked);
    }

    public async void OnItemClicked(Lecture selectedLecture)
    {
        await Shell.Current.Navigation.PushAsync(new LectureInfoPage(selectedLecture));
    }


    public async void GoToAddLecturePage(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new AddLecturePage());
	}

	protected override void OnAppearing()
    {
        LoadLectures();
    }

    private void LoadLectures()
    {
        var lecturesList = App.LectureHelper.GetAllLectures();

        lectures.Clear();

        foreach (Lecture lecture in lecturesList)
        {
            lectures.Add(lecture);
        }
    }

    private void searchLecture(object sender, TextChangedEventArgs e)
	{
        string query = e.NewTextValue;

        lectures.Clear();

		List<Lecture> lectureList = App.LectureHelper.SearchLectureByName(query);

		foreach (Lecture lecture in lectureList)
		{
			lectures.Add(lecture);
		}
	}
}