using Avenga.TodoApp.Services.Dtos;
using Avenga.TodoApp.ViewModels;

namespace Avenga.TodoApp.Services.Services.Interfaces
{
    public interface ITodoService
    {
        IEnumerable<TodoDto> GetAllTodos();
        void AddTodo(CreateTodoVM createTodoVM);
        bool MarkComplete(int todoId);
        void RemoveComplete();
    }
}
