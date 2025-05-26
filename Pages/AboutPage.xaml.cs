namespace AcademiApp.Pages;

public partial class AboutPage : ContentPage
{
	public AboutPage()
	{
		InitializeComponent();
	}

	public async void OnLinkedinClicked(object sender, EventArgs e)
	{
        try
        {
            Uri uri = new Uri("https://www.linkedin.com/in/nathan-yan-alves/");
            await Launcher.Default.OpenAsync(uri);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Não foi possível abrir o link: {ex.Message}", "OK");
        }
    }

    public async void OnGithubClicked(object sender, EventArgs e)
    {
        
        try
        {
            Uri uri = new Uri("https://github.com/nathanYanDev");
            await Launcher.Default.OpenAsync(uri);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Não foi possível abrir o link: {ex.Message}", "OK");
        }
    }
}