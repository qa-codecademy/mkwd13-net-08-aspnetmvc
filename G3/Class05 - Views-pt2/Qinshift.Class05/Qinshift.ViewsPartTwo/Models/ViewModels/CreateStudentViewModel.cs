namespace Qinshift.ViewsPartTwo.Models.ViewModels
{
    public class CreateStudentViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? ActiveCourseId { get; set; }
    }
}
