using System.ComponentModel.DataAnnotations;

namespace Avenga.TodoApp.Domain
{
    public class Todo : BaseEntity
    {
        [MaxLength(10)]
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
