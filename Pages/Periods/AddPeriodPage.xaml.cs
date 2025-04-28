using AcademiApp.Models;
namespace AcademiApp.Pages.Periods;

public partial class AddPeriodPage : ContentPage
{
	public AddPeriodPage()
	{
		InitializeComponent();
	}

	private async void AddPeriodButton_Clicked(object sender, EventArgs e)
	{
		try
		{
			Period period = new()
            {
				Name = etrPeriodName.Text,
				Code = etrPeriodCode.Text,
			};

			App.PeriodHelper.AddPeriod(period);

			await DisplayAlert("Sucesso", "Registro inserido com sucesso!", "OK");

			await Navigation.PushAsync(new ListPeriodsPage());
		}
		catch (Exception ex)
		{
			await DisplayAlert("Erro", ex.Message, "OK");
		}
	}
}