using Avenga.TodoApp.Services.Dtos;

namespace Avenga.TodoApp.Services.Services.Interfaces
{
    public interface ITodoService
    {
        IEnumerable<TodoDto> GetAllTodos();
    }
}
