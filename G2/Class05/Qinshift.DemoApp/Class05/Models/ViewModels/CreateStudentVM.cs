namespace Class05.Models.ViewModels
{
    public class CreateStudentVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? ActiveCourseId { get; set; }
        public List<CourseOptionVM> Courses { get; set; }

    }
}
