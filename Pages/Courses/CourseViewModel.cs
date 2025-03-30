using AcademiApp.Pages.Lectures;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Xml.Serialization;

namespace AcademiApp.Pages.Courses
{
    public class CourseViewModel
    {
        public required ObservableCollection<Course> Courses { get; set; }
        public ICommand ItemClickedCommand { get; }

        public CourseViewModel() 
        {
            ItemClickedCommand = new Command<Course>(OnItemClicked);
            Courses = new ObservableCollection<Course>();
            OnLoadingTestData();
        }

        public async void OnItemClicked(Course selectedCourse)
        {
            await Shell.Current.Navigation.PushAsync(new CourseInfoPage(selectedCourse));
        }

        private void OnLoadingTestData()
        {
            Courses.Add(new Course { CourseCode = "ESOFT-2023", CourseName = "Engenharia de Software", CoursePeriod = "01/25", CourseDescription = "Formação em desenvolvimento de sistemas complexos e gestão de projetos de software.", Lectures = [new Lecture { LectureCode = "POO-101", LectureDescription = "Fundamentos de OOP com Java e C#.", LectureName = "Programação Orientada a Objetos", Courses = [] }, new Lecture { LectureCode = "BD-101", LectureDescription = "Modelagem relacional e SQL.", LectureName = "Banco de dados", Courses = [] }, new Lecture { LectureCode = "WEB-101", LectureDescription = "Desenvolvimento web com HTML, CSS e JS.", LectureName = "Desenvolvimento Web", Courses = [] }] });
            Courses.Add(new Course { CourseCode = "CDAD-2023", CourseName = "Ciência de Dados", CoursePeriod = "02/26", CourseDescription = "Formação em análise de dados, machine learning e visualização de informações.", Lectures = [new Lecture { LectureCode = "POO-101", LectureDescription = "Fundamentos de OOP com Java e C#.", LectureName = "Programação Orientada a Objetos", Courses = [] }, new Lecture { LectureCode = "BD-101", LectureDescription = "Modelagem relacional e SQL.", LectureName = "Banco de dados", Courses = [] }, new Lecture { LectureCode = "WEB-101", LectureDescription = "Desenvolvimento web com HTML, CSS e JS.", LectureName = "Desenvolvimento Web", Courses = [] }] });
            Courses.Add(new Course { CourseCode = "MED-2023", CourseName = "Medicina", CoursePeriod = "01/25", CourseDescription = "Formação médica com ênfase em clínica geral e especializações.", Lectures = [new Lecture { LectureCode = "ANAT-401", LectureDescription = "Anatomia humana e fisiologia.", LectureName = "Anatomia Humana", Courses = [] }] });
            Courses.Add(new Course { CourseCode = "DIR-2023", CourseName = "Direito", CoursePeriod = "02/25", CourseDescription = "Formação jurídica com ênfase em direito civil, penal e trabalhista.", Lectures = [] });
            Courses.Add(new Course { CourseCode = "ADM-2023", CourseName = "Administração", CoursePeriod = "01/26", CourseDescription = "Formação em gestão de negócios e administração de empresas.", Lectures = [] });
        }
    }
}
