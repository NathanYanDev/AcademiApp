using AcademiApp.Models;
using System.Collections.ObjectModel;

namespace AcademiApp.Pages.Periods;

public partial class ListPeriodsPage : ContentPage
{
	ObservableCollection<Period> periods = new();

	public ListPeriodsPage()
	{
		InitializeComponent();

		lstPeriods.ItemsSource = periods;
    }

	protected override async void OnAppearing()
    {
        await LoadPeriodsAsync();
    }

    private async Task LoadPeriodsAsync()
	{
		List<Period> tmp = App.PeriodHelper.GetAllPeriods();

        periods.Clear();

        foreach (Period period in tmp)
        {
            periods.Add(period);
        }
    }

    public async void GoToAddPeriodPage(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new AddPeriodPage());
	}
}