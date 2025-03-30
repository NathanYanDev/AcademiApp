namespace AcademiApp.Pages.Lectures;

public partial class EditLecturePage : ContentPage
{
    private Lecture _editLecture;

    public Lecture EditLecture
    {
        get => _editLecture;
        set
        {
            _editLecture = value;
            OnPropertyChanged(nameof(EditLecture));
        }
    }

    public EditLecturePage(Lecture lecture)
    {
        InitializeComponent();
        EditLecture = lecture;
        BindingContext = this;
    }
}