namespace AcademiApp.Pages;

public partial class UserRegisterPage : ContentPage
{
	public UserRegisterPage()
	{
		InitializeComponent();
	}

	public async void OnBackButtonClicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync("//MainPage");
    }
}