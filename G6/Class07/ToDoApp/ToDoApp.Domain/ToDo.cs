namespace ToDoApp.Domain
{
    public class ToDo : BaseEntity
    {
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public int StatusId { get; set; }
        public int CategoryId { get; set; }
    }
}
