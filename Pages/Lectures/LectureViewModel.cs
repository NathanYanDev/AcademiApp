using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Xml.Serialization;

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
            OnLoadingTestData();
        }

        public async void OnItemClicked(Lecture selectedLecture)
        {
            await Shell.Current.Navigation.PushAsync(new LectureInfoPage(selectedLecture));
        }

        public void OnLoadingTestData()
        {
            Lectures.Add(new Lecture { LectureCode = "POO-101", LectureDescription = "Fundamentos de OOP com Java e C#.", LectureName = "Programação Orientada a Objetos", Courses = [] });
            Lectures.Add(new Lecture { LectureCode = "BD-101", LectureDescription = "Modelagem relacional e SQL.", LectureName = "Banco de dados", Courses = [] });
            Lectures.Add(new Lecture { LectureCode = "WEB-101", LectureDescription = "Desenvolvimento web com HTML, CSS e JS.", LectureName = "Desenvolvimento Web", Courses = [] });
            Lectures.Add(new Lecture { LectureCode = "IA-101", LectureDescription = "Introdução à inteligência artificial.", LectureName = "Inteligência Artificial", Courses = [] });
            Lectures.Add(new Lecture { LectureCode = "ANAT-401", LectureDescription = "Anatomia humana e fisiologia.", LectureName = "Anatomia Humana", Courses = [] });
        }
    }
}
