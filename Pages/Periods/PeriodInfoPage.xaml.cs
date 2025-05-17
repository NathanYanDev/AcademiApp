namespace AcademiApp.Pages.Periods;
using AcademiApp.Models;

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

    private async void DeletePeriodEvent(object sender, EventArgs e)
    {
        try
        {
            bool confirmExclusion = await DisplayAlert("Confirmação", "Confirma a remoção?", "Sim", "Não");

            if (confirmExclusion)
            {
                App.PeriodHelper.DeletePeriod(SelectedPeriod.Id);

                await Shell.Current.GoToAsync("..");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", "Ocorreu um erro enquanto deletava o período: " + ex.Message, "OK");
        }
    }
}