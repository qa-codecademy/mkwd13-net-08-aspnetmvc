namespace Qinshift.Views.Models.ViewModels
{
    public class CourseWithStudentsViewModel
    {
        public string CourseName { get; set; }
        public int NumberOfClasses { get; set; }
        public List<StudentInfoViewModel> Students { get; set; }
    }
}
