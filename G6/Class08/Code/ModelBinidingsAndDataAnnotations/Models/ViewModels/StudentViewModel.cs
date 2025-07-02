using System.ComponentModel.DataAnnotations;

namespace ModelBinidingsAndDataAnnotations.Models.ViewModels
{
    public class StudentViewModel
    {
        public int Id { get; set; }

        //specifies the display name for the FullName property
        //we can use it with html helpers or tag helpers such as labels, table header etc 
        [Display(Name = "Full name")]
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }
}
