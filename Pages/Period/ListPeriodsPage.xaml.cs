namespace AcademiApp.Pages.Period;

public partial class ListPeriodsPage : ContentPage
{
	public ListPeriodsPage()
	{
		InitializeComponent();
	}

	public async void GoToAddPeriodPage(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new AddPeriodPage());
	}
}