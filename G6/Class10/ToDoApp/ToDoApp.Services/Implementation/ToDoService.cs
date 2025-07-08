using ToDoApp.DataAccess.EFImplementation;
using ToDoApp.DataAccess.Implementation;
using ToDoApp.DataAccess.Interfaces;
using ToDoApp.Domain;
using ToDoApp.Models.ViewModels;
using ToDoApp.Services.Interfaces;

namespace ToDoApp.Services.Implementation
{
    public class ToDoService : IToDoService
    {
        private readonly IRepository<ToDo> _toDoRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Status> _statusRepository;

        public ToDoService(IRepository<ToDo> toDoRepository, 
            IRepository<Category> categoryRepository, 
            IRepository<Status> statusRepository)
        {
            //this way we need to create a concrete instance
            //this way our class is tightly coupled to a concrete impl
            //_toDoRepository = new ToDoRepository();

            _toDoRepository = toDoRepository;
            _categoryRepository = categoryRepository;
            _statusRepository = statusRepository;
        }
        public List<ToDosViewModel> GetAllTodos(int? categoryId, int? statusId)
        {
            //get all toDos

            List<ToDo> todos = _toDoRepository.GetAll();

            //filter
            if(categoryId.HasValue && categoryId.Value > 0)
            {
                todos = todos.Where(x => x.CategoryId == categoryId.Value).ToList();
            }
            if(statusId.HasValue && statusId.Value > 0)
            {
                todos = todos.Where(x => x.StatusId == statusId.Value).ToList();
            }

            //we need to map the domain model to view model
            var result = new List<ToDosViewModel>();
            foreach(ToDo todo in todos)
            {
                result.Add(new ToDosViewModel
                {
                    Id = todo.Id,
                    Description = todo.Description,
                    DueDate = todo.DueDate,
                    CategoryName = _categoryRepository.GetById(todo.CategoryId)?.Name ?? string.Empty,
                    StatusName = _statusRepository.GetById(todo.StatusId)?.Name ?? string.Empty
                }); 
            }

            return result;
        }

		public void AddTodo(CreateTodoViewModel createTodo)
		{
			var newTodo = new ToDo
			{
				Description = createTodo.Description,
				CategoryId = createTodo.CategoryId,
				DueDate = createTodo.DueDate,
				StatusId = 1
			};
			_toDoRepository.Create(newTodo);
		}

		public bool MarkComplete(int todoId)
		{
			var todo = _toDoRepository.GetById(todoId);

			if (todo == null) return false;

			todo.StatusId = 2; //Completed
			_toDoRepository.Update(todo);

			return true;
		}

		public void RemoveComplete()
		{
			var completedTodos = _toDoRepository.GetAll().Where(x => x.StatusId == 2).ToList();
			foreach (var todo in completedTodos)
			{
				_toDoRepository.Delete(todo.Id);
			}
		}
	}
}
