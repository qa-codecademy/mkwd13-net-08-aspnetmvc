using System.ComponentModel.DataAnnotations;

namespace Qinshift.ModelBindingAndValidations.Models.ViewModels
{
    public class CreateStudentViewModel
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
