using AcademiApp.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AcademiApp.Pages.Periods;

public partial class ListPeriodsPage : ContentPage
{
	ObservableCollection<Period> periods = new();

    public ICommand ItemClickedCommand { get; }

    public ListPeriodsPage()
	{
		InitializeComponent();

		lstPeriods.ItemsSource = periods;

        ItemClickedCommand = new Command<Period>(OnItemClicked);
    }

    public async void OnItemClicked(Period selectedPeriod)
    {
        await Shell.Current.Navigation.PushAsync(new PeriodInfoPage(selectedPeriod));
    }

    protected override void OnAppearing()
    {
        LoadPeriods();
    }

    private void LoadPeriods()
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

    private void searchPeriod(object sender, TextChangedEventArgs e)
    {
        string query = e.NewTextValue;

        periods.Clear();

        List<Period> periodList = App.PeriodHelper.SearchPeriodByName(query);

        foreach (Period period in periodList)
        {
            periods.Add(period);
        }
    }
}