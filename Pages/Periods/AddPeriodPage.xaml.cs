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
			if (string.IsNullOrEmpty(etrPeriodName.Text))
			{
				await DisplayAlert("Erro", "O nome do período é obrigatório.", "OK");
				return;
			}

			if (string.IsNullOrEmpty(etrPeriodCode.Text))
			{
                await DisplayAlert("Erro", "O código do período é obrigatório.", "OK");
                return;
            }

            Period period = new Period
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