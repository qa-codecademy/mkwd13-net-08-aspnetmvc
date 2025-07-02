namespace Avenga.TodoApp.ViewModels
{
    public class CreateTodoVM
    {
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public List<CategoryVM> Categories { get; set; } = new List<CategoryVM>();
        public int CategoryId { get; set; }
        public int StatusId { get; set; }
    }
}
