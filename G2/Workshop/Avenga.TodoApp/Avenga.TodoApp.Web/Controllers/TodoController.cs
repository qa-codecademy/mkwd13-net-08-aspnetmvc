using Avenga.TodoApp.Services.Dtos;
using Avenga.TodoApp.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Avenga.TodoApp.Web.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        public IActionResult Index()
        {
            List<TodoDto> todos = _todoService.GetAllTodos().ToList();

            return View(todos);
        }
    }
}
