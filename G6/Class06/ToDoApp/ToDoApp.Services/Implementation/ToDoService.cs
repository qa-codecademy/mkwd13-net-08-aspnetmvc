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

        public ToDoService(IRepository<ToDo> toDoRepository)
        {
            //this way we need to create a concrete instance
            //this way our class is tightly coupled to a concrete impl
            //_toDoRepository = new ToDoRepository();
            _toDoRepository = toDoRepository;
        }
        public List<ToDosViewModel> GetAllTodos(int? categoryId, int? statusId)
        {
            //get all toDos

            List<ToDo> todosFromDb = _toDoRepository.GetAll();
        }
    }
}
