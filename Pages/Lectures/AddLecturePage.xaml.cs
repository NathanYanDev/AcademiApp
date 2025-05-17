using AcademiApp.Models;

namespace AcademiApp.Pages.Lectures;

public partial class AddLecturePage : ContentPage
{
	public AddLecturePage()
	{
		InitializeComponent();
	}

    private async void SaveChanges(object sender, EventArgs e)
    {
        try
        {
            if(string.IsNullOrWhiteSpace(etrLectureName.Text))
            {
                await DisplayAlert("Erro", "O nome da disciplina � obrigat�rio.", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(etrLectureCode.Text))
            {
                await DisplayAlert("Erro", "O c�digo da disciplina � obrigat�rio.", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(editorLectureDescription.Text))
            {
                await DisplayAlert("Erro", "A descri��o da disciplina � obrigat�ria.", "OK");
                return;
            }

            Lecture lecture = new Lecture
            {
                Name = etrLectureName.Text,
                Code = etrLectureCode.Text,
                Description = editorLectureDescription.Text
            };

            App.LectureHelper.AddLecture(lecture);

            await DisplayAlert("Sucesso", "Registro inserido com sucesso!", "OK");

            await Navigation.PushAsync(new ListLecturesPage());
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "OK");
        }
    }
}