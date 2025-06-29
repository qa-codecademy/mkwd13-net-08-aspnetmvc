using Microsoft.AspNetCore.Mvc;
using TodoApplication.Services;

namespace TodoApplication.Controllers {
	[Route("")]
	public class TodoController : Controller {
		private readonly TodoService _todoService;

		public TodoController() {
			_todoService = new TodoService();
		}
		public IActionResult Index() {
			int? categoryId = null;
			int? statusId = null;

			var todos = _todoService.GetTodos(categoryId, statusId);
			return View(todos);
		}

		[HttpGet("mark-complete")]
		public IActionResult MarkComplete(int id) {
			var todoMarkComplete = _todoService.MarkComplete(id);
			if (!todoMarkComplete) {
				TempData["ErrorMessage"] = "Todo does note exists";
			}
			return RedirectToAction("Index");
		}

		[HttpGet("remove-complete")]
		public IActionResult RemoveComplete() {
			_todoService.RemoveComplete();
			return RedirectToAction("Index");
		}

		[HttpGet("add")]
		public IActionResult AddTodo() {
			return View();
		}
	}
}
