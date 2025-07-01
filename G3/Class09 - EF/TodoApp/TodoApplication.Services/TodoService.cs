
using TodoApplication.DataAccess.Implementations;
using TodoApplication.DataAccess.Interfaces;
using TodoApplication.Domain;
using TodoApplication.Dtos.Dto;
using TodoApplication.Dtos.ViewModel;
using TodoApplication.Services.Interfaces;

namespace TodoApplication.Services {
	public class TodoService : IToDoService {
		private readonly ITodoRepository _todoRepository;
		private readonly IRepository<Category> _categoryRepository;
		private readonly IRepository<Status> _statusReposity;

		public TodoService() {
			_todoRepository = new TodoRepository();
			_categoryRepository = new CategoryRepository();
			_statusReposity = new StatusRepository();
		}

		public List<TodoDto> GetTodos(int? categoryId, int? statusId) {
			var todos = _todoRepository.GetAll();

			if(categoryId.HasValue && categoryId.Value > 0) 
			{
				todos = todos.Where(t => t.CategoryId == categoryId.Value).ToList();
			}

			if(statusId.HasValue && statusId > 0) 
			{
				todos = todos.Where(t => t.StatusId == statusId.Value).ToList();
			}

			var result = new List<TodoDto>();
			
			foreach (var todo in todos) 
			{
				result.Add(new TodoDto {
					Id = todo.Id,
					Description = todo.Description,
					DueDate = todo.DueDate,
					Category = _categoryRepository.GetById(todo.CategoryId).Name ?? string.Empty,
					Status = _statusReposity.GetById(todo.StatusId).Name ?? string.Empty,
					StatusId = todo.StatusId,
				});
			}
			return result;
		}

		public void AddTodo(CreateTodoVM createTodo) {
			var newTodo = new Todo {
				Description = createTodo.Description,
				CategoryId = createTodo.CategoryId,
				DueDate = createTodo.DueDate,
				StatusId = 1
			};
			_todoRepository.Add(newTodo);
		}

		public bool MarkComplete(int todoId) {
			var todo = _todoRepository.GetById(todoId);

			if (todo == null) return false;

			todo.StatusId = 2;
			_todoRepository.Update(todo);

			return true;
		}

		public void RemoveComplete() {
			var completeTodos = _todoRepository.GetCompletedTodos();
			foreach (var todo in completeTodos) 
			{
				_todoRepository.Delete(todo.Id);
			}
		}

	}
}
