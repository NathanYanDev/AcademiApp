namespace AcademiApp.Pages.Periods;
using AcademiApp.Models;

public partial class EditPeriodPage : ContentPage
{
    private Period _editPeriod;

    public Period EditPeriod
    {
        get => _editPeriod;
        set
        {
            _editPeriod = value;
            OnPropertyChanged(nameof(EditPeriod));
        }
    }

    public EditPeriodPage(Period course)
    {
        InitializeComponent();
        EditPeriod = course;
        BindingContext = this;
    }

    private async void SaveEditedChanges(object sender, EventArgs e)
    {
        try
        {
            Period period = new Period();

            period.Id = EditPeriod.Id;
            period.Name = etrPeriodName.Text;
            period.Code = etrPeriodCode.Text;

            if (string.IsNullOrEmpty(period.Name) || string.IsNullOrEmpty(period.Code))
            {
                await DisplayAlert("Erro", "Por favor preencha todos os campos", "OK");
            }
            else
            {
                App.PeriodHelper.UpdatePeriod(period);

                await DisplayAlert("Sucesso", "Período atualizado com sucesso", "OK");

                await Shell.Current.GoToAsync("../..");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "OK");
        }
    }

    private async void ReturnPage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}