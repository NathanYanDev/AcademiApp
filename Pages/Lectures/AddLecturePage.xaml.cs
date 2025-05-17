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
                await DisplayAlert("Erro", "O nome da disciplina é obrigatório.", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(etrLectureCode.Text))
            {
                await DisplayAlert("Erro", "O código da disciplina é obrigatório.", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(editorLectureDescription.Text))
            {
                await DisplayAlert("Erro", "A descrição da disciplina é obrigatória.", "OK");
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