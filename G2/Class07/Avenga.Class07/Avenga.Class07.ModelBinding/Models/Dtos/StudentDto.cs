using System.ComponentModel.DataAnnotations;

namespace Avenga.Class07.ModelBinding.Models.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; }


        //[Display(Name = "Име на студент")]
        [Display(Name = "Student's full name")]
        public string FullName { get; set; }


        //[Display(Name="Години")]
        [Display(Name = "Student's age")]
        public int Age { get; set; }
    }
}
