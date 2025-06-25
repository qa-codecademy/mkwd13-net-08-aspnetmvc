using System.ComponentModel.DataAnnotations;

namespace Qinshift.ModelBindingAndValidations.Models.ViewModels
{
    // 1. Define Validation Rules (using attributes)
    // 2. Add asp-validation-for tag helper in the view for each input
    // 3. Check the ModelState in the Controller Action 
    public class CreateStudentViewModel
    {
        [Display(Name = "First Name")]
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "ENTER LAST NAME !!!!!!!!")]
        [StringLength(maximumLength: 20, MinimumLength = 3)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "The Date of birth field is REQUIRED !")]
        public DateTime? DateOfBirth { get; set; } = null;
        [EmailAddress(ErrorMessage = "Invalid Email address! Please enter valid one!")]
        public string Email { get; set; }
        [Phone(ErrorMessage = "Invalid phone number!")]
        public string PhoneNumber { get; set; }

        // More Validation Attributes: [Range], [Compare], [RegularExpression], [Url], custom-made validation attributes...
        //[StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 100 characters")]
        //public string Password { get; set; }
        //[Compare("Password", ErrorMessage = "The password and confirmation password do not match")]
        //public string ConfirmPassword { get; set; }
    }
}
