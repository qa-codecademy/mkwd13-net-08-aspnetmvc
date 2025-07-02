using Avenga.TodoApp.DataAccess.Data;
using Avenga.TodoApp.DataAccess.Repositories;
using Avenga.TodoApp.Domain;
using Avenga.TodoApp.Services.Dtos;
using Avenga.TodoApp.Services.Services.Interfaces;
using Avenga.TodoApp.ViewModels;

namespace Avenga.TodoApp.Services.Services
{
    public class TodoService : ITodoService
    {
        private readonly IRepository<Todo> _todoRepository;
        public TodoService(IRepository<Todo> todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public void AddTodo(CreateTodoVM createTodoVM)
        {
            var newTodo = new Todo
            {
                Id = StaticDb.Todos.Count + 1,
                Description = createTodoVM.Description,
                DueDate = createTodoVM.DueDate,
                CategoryId = createTodoVM.CategoryId,
                StatusId = 1
            };

            _todoRepository.Create(newTodo);
        }

        public IEnumerable<TodoDto> GetAllTodos()
        {
            var todosDto = new List<TodoDto>();
            IEnumerable<Todo> todos = _todoRepository.GetAll();
            if (todos != null && todos.ToList().Count > 0)
            {
                // Map from Todo to TodoDto
                foreach (var todo in todos)
                {
                    todosDto.Add(new TodoDto
                    {
                        Id = todo.Id,
                        Description = todo.Description,
                        DueDate = todo.DueDate,
                        Category = StaticDb.Categories.SingleOrDefault(x => x.Id == todo.CategoryId).Name,
                        Status = StaticDb.Statuses.SingleOrDefault(x => x.Id == todo.StatusId).Name,
                        StatusId = todo.StatusId 
                    });
                }
                return todosDto;
            }
            return todosDto;
        }


    }
}
