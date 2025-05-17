namespace AcademiApp.Pages.Lectures;
using AcademiApp.Models;

public partial class EditLecturePage : ContentPage
{
    private Lecture _editLecture;

    public Lecture EditLecture
    {
        get => _editLecture;
        set
        {
            _editLecture = value;
            OnPropertyChanged(nameof(EditLecture));
        }
    }

    public EditLecturePage(Lecture lecture)
    {
        InitializeComponent();
        EditLecture = lecture;
        BindingContext = this;
    }

    private async void SaveEditedChanges(object sender, EventArgs e)
    {
        try
        {
            Lecture lecture = new Lecture();

            lecture.Id = EditLecture.Id;
            lecture.Name = etrLectureName.Text;
            lecture.Code = etrLectureCode.Text;
            lecture.Description = editorLectureDescription.Text;

            if (string.IsNullOrEmpty(lecture.Name) || string.IsNullOrEmpty(lecture.Code) || string.IsNullOrEmpty(lecture.Description))
            {
                await DisplayAlert("Erro", "Please fill all fields", "OK");
            }
            else
            {
                App.LectureHelper.UpdateLecture(lecture);

                await DisplayAlert("Sucesso", "Disciplina atualizada com sucesso", "OK");

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