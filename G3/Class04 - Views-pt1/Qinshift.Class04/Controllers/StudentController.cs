using Microsoft.AspNetCore.Mvc;
using Qinshift.Class04.Database;
using Qinshift.Class04.Models.DtoModels;

namespace Qinshift.Class04.Controllers {
	[Route("students")]
	public class StudentController : Controller {
		public IActionResult Index() {
			return View(InMemoryDatabase.Students
				.Select(student => new StudentWithCourseDto(
					student.Id,
					student.FirstName,
					student.LastName,
					student.DateOfBirth,
					student.ActiveCourse.Id,
					student.ActiveCourse.Name
					)));
		}

		[HttpGet("{id}")]
		public IActionResult GetStudentById(int id) {
			var student = InMemoryDatabase.Students.FirstOrDefault(student => student.Id == id);

			if(student == null) {
				return View();
			}

			var studentWithCourse = new StudentWithCourseDto(
				student.Id,
				student.FirstName,
				student.LastName,
				student.DateOfBirth,
				student.ActiveCourse.Id,
				student.ActiveCourse.Name
				);

			return View(studentWithCourse);
		}
	}
}
