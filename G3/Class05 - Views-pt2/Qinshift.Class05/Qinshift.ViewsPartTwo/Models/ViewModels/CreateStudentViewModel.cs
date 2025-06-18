using System.ComponentModel.DataAnnotations;

namespace Qinshift.ViewsPartTwo.Models.ViewModels
{
    public class CreateStudentViewModel
    {
        [Display(Name = "First Name")]
        // this name will be displayed when Html.LabelFor (or similar methods) is used
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? ActiveCourseId { get; set; }

        // For Course Dropdown list
        public List<CourseOptionViewModel> Courses { get; set; }
    }
}
