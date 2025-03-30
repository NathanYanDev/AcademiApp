namespace AcademiApp.Pages.Lectures;

public partial class ListLecturesPage : ContentPage
{
	public ListLecturesPage()
	{
		InitializeComponent();
	}

	public async void GoToAddLecturePage(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new AddLecturePage());
	}
}