using AcademiApp.Helpers;

namespace AcademiApp
{
    public partial class App : Application
    {
        private static SQLiteDatabaseHelpers _db;
        private static CourseHelper _courseHelper;
        private static LectureHelper _lectureHelper;
        private static PeriodHelper _periodHelper;

        public static SQLiteDatabaseHelpers Db
        {
            get
            {
                if (_db == null)
                {
                    string path = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "academiApp.db3");
                    _db = new SQLiteDatabaseHelpers(path);
                }
                return _db;
            }
        }

        public static CourseHelper CourseHelper
        {
            get
            {
                if (_courseHelper == null)
                {
                    _courseHelper = new CourseHelper(Db);
                }
                return _courseHelper;
            }
        }

        public static LectureHelper LectureHelper
        {
            get
            {
                if (_lectureHelper == null)
                {
                    _lectureHelper = new LectureHelper(Db);
                }
                return _lectureHelper;
            }
        }

        public static PeriodHelper PeriodHelper
        {
            get
            {
                if (_periodHelper == null)
                {
                    _periodHelper = new PeriodHelper(Db);
                }
                return _periodHelper;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
