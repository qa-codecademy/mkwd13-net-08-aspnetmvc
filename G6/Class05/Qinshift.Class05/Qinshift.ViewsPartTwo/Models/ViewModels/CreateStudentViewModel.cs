using System.ComponentModel.DataAnnotations;

namespace Qinshift.ViewsPartTwo.Models.ViewModels
{
    public class CreateStudentViewModel
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Prezime")]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int ActiveCourseId { get; set; }

        public List<CourseOptionViewModel> Courses { get; set; }
    }
}
