using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Xml.Serialization;
using AcademiApp.Models;

namespace AcademiApp.Pages.Lectures
{
    class LectureViewModel
    {
        public required ObservableCollection<Lecture> Lectures { get; set; }
        public ICommand ItemClickedCommand { get; }

        public LectureViewModel() 
        {
            ItemClickedCommand = new Command<Lecture>(OnItemClicked);
            Lectures = new ObservableCollection<Lecture>();
        }

        public async void OnItemClicked(Lecture selectedLecture)
        {
            await Shell.Current.Navigation.PushAsync(new LectureInfoPage(selectedLecture));
        }
    }
}
