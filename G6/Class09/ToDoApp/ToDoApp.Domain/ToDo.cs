namespace ToDoApp.Domain
{
    public class ToDo : BaseEntity
    {
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public Status Status { get; set; } //we need it here in order to represent the relationship with status
        public int StatusId { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
