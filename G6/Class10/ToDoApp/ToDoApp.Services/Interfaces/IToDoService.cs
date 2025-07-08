using ToDoApp.Models.ViewModels;

namespace ToDoApp.Services.Interfaces
{
    public interface IToDoService
    {
        //categoryId and statusId are optional - we can filter, but we don't always have to
        List<ToDosViewModel> GetAllTodos(int? categoryId, int? statusId);

        void AddTodo(CreateTodoViewModel createTodo);
        bool MarkComplete(int todoId);
        void RemoveComplete();

	}
}
