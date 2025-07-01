using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Avenga.TodoApp.Services.Dtos
{
    public class TodoDto
    {
        public int Id { get; set; }

        [Display(Name = "Todo Description")]
        public string Description { get; set; }

        [Display(Name = "Done until")]
        public DateTime DueDate { get; set; }

        [Display(Name = "Todo category")]
        public string Category { get; set; }

        [DisplayName("Todo status")]
        public string Status { get; set; }

        public int StatusId { get; set; }
    }
}
