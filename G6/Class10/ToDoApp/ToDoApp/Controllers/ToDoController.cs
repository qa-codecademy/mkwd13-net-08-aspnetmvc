using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models.Dtos;
using ToDoApp.Models.ViewModels;
using ToDoApp.Services.Implementation;
using ToDoApp.Services.Interfaces;

namespace ToDoApp.Controllers
{
    [Route("todo")]
    public class ToDoController : Controller
    {
        private readonly IToDoService _todoService;
        private readonly IFilterService _filterService;

        public ToDoController(IToDoService todoService, IFilterService filterService)
        {
            // _todoService = new ToDoService();
            _todoService = todoService;
            _filterService = filterService;
        }

        public IActionResult Index()
        {
            int? categoryId = null;
            int? statusId = null;

            ViewBag.Filter = new FilterDto();

            if (TempData["HasFilter"] != null)
            {
                //this way we can pass the selected filters to the GetAllTodos method
                categoryId = (int?)TempData["Category"];
                statusId = (int?)TempData["Status"];

                //this way we pass on the selected filters to the view, because when we call this action, the whole page will be refreshed and reloaded and we need to pass on the selected filters
                ViewBag.Filter.CategoryId = categoryId;
                ViewBag.Filter.StatusId = statusId; 
            }

            ViewBag.Filter.Categories = _filterService.GetCategories();
            ViewBag.Filter.Statuses = _filterService.GetStatuses();

            List<ToDosViewModel> todos = _todoService.GetAllTodos(categoryId, statusId);
            return View(todos);
        }

        [HttpPost("filter")]
        public IActionResult Filter(FilterViewModel filters)
        {
            //we pass on the filtered values to the index action using temp data
            TempData["HasFilter"] = true;
            TempData["Category"] = filters.CategoryId;
            TempData["Status"] = filters.StatusId;

            return RedirectToAction("Index");
        }

		[HttpGet("markComplete")]
		public IActionResult MarkComplete(int id)
		{
			_todoService.MarkComplete(id);
			return RedirectToAction("Index");
		}

		[HttpGet("removeComplete")]
		public IActionResult RemoveComplete()
		{
			_todoService.RemoveComplete();
			return RedirectToAction("Index");
		}

		[HttpGet("add")]
		public IActionResult AddTodo()
		{
			ViewBag.Categories = _filterService.GetCategories();
			return View("AddTodo");
		}

		[HttpPost("add")]
		public IActionResult AddTodo(CreateTodoViewModel createTodoViewModel)
		{
			if (createTodoViewModel.CategoryId == 0)
			{
				ViewBag.Categories = _filterService.GetCategories();
				return View(createTodoViewModel);
			}

			_todoService.AddTodo(createTodoViewModel);
			return RedirectToAction("Index");
		}
	}
}
