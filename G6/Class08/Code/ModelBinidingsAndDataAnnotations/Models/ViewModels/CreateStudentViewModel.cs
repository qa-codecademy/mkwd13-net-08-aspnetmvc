using System.ComponentModel.DataAnnotations;

namespace ModelBinidingsAndDataAnnotations.Models.ViewModels
{
    public class CreateStudentViewModel
    {
        [Required]
        [MinLength(3, ErrorMessage="The first name must have at least three characters")]
        [MaxLength(20)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }


        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage ="The last name must have at least 3 chars and max 20 chars")] //combines MinLength and MaxLength
        [Display(Name = "Last name")]
        public string LastName { get; set; }


        [Required(ErrorMessage ="Date of birth is a required field")]
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }

        [EmailAddress] //validates that the email is in a valid format
        public string Email { get; set; }

        [Phone]//validates that the phone is in a correct format (with numbers)
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
    }
}
