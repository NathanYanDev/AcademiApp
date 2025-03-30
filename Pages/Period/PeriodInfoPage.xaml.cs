namespace AcademiApp.Pages.Period;

public partial class PeriodInfoPage : ContentPage
{
    private Period _selectedPeriod;

    public Period SelectedPeriod
    {
        get => _selectedPeriod;
        set
        {
            _selectedPeriod = value;
            OnPropertyChanged();
        }
    }
    public PeriodInfoPage(Period selectedPeriod)
    {
        InitializeComponent();
        BindingContext = this;
        SelectedPeriod = selectedPeriod;
    }

    public PeriodInfoPage()
	{
		InitializeComponent();
	}

    private async void EditPeriodEvent(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EditPeriodPage(SelectedPeriod));
    }
}