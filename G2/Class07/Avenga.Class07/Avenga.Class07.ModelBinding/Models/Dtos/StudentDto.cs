using System.ComponentModel.DataAnnotations;

namespace Avenga.Class07.ModelBinding.Models.Dtos
{
    public class StudentDto
    {
        [Display(Name = "Student's full name")]
        public string FullName { get; set; }

        [Display(Name = "Student's age")]
        public int Age { get; set; }
    }
}
