namespace AcademiApp.Pages.Lectures;
using AcademiApp.Models;

public partial class LectureInfoPage : ContentPage
{
	private Lecture _selectedLecture;

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
    }

    public LectureInfoPage()
	{
		InitializeComponent();
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