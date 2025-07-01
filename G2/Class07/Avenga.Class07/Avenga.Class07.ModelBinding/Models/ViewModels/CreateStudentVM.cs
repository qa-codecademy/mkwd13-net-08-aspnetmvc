using System.ComponentModel.DataAnnotations;

namespace Avenga.Class07.ModelBinding.Models.ViewModels
{
    public class CreateStudentVM
    {
        [Required(ErrorMessage = "Firstname is required field.")]
        [MinLength(3, ErrorMessage = "Firstname must have at least 3 characters.")]
        [MaxLength(30, ErrorMessage = "Firstname should have maximum 30 characters.")]
        [Display(Name = "Firstname")]
        public string FirstName { get; set; }



        [Required(ErrorMessage = "Lastname is required field.")]
        [MinLength(3, ErrorMessage = "Lastname must have at least 3 characters.")]
        [MaxLength(30, ErrorMessage = "Lastname should have maximum 30 characters.")]
        [Display(Name = "Lastname")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Email is required field.")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        
        [Display(Name = "Additional info")]
        [MinLength(5, ErrorMessage = "Additional info must have at least 5 characters.")]
        [MaxLength(50, ErrorMessage = "Additional info should have maximum 50 characters.")]
        public string? AdditionalInfo { get; set; }


        [Required(ErrorMessage = "Date of birth is required field.")]
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }
        
    }
}
