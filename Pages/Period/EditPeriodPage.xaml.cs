namespace AcademiApp.Pages.Period;

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


}