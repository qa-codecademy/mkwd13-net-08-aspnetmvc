namespace ToDoApp.Models.ViewModels
{
	public class CreateTodoViewModel
	{
		public string Description { get; set; }
		public DateTime DueDate { get; set; }
		public int CategoryId { get; set; }
	}
}
