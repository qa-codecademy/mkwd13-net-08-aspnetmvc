using Avenga.TodoApp.Services.Dtos;
using Avenga.TodoApp.Services.Services.Interfaces;
using Avenga.TodoApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Avenga.TodoApp.Web.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;
        private readonly ICategoryService _categoryService;
        public TodoController(ITodoService todoService, ICategoryService categoryService)
        {
            _todoService = todoService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            List<TodoDto> todos = _todoService.GetAllTodos().ToList();

            return View(todos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateTodoVM createTodoVM = new CreateTodoVM();
            createTodoVM.DueDate = DateTime.Now;
            createTodoVM.Categories = _categoryService.GetAllCategories();
            return View(createTodoVM);
        }

        [HttpPost]
        public IActionResult Create(CreateTodoVM model)
        {
            if (ModelState.IsValid)
            {
                _todoService.AddTodo(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult MarkComplete(int id)
        {
                var response = _todoService.MarkComplete(id);
            if(!response)
            {
                //TempData["ErrorMessage"] = "Todo does not exists!";
                ViewBag.ErrorMessage = "Todo does not exists!";
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult RemoveComplete()
        {
            _todoService.RemoveComplete();
            return RedirectToAction("Index");
        }
    }
}
