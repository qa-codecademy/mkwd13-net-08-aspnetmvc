using Microsoft.AspNetCore.Mvc;
using Qinshift.Class04.Database;
using Qinshift.Class04.Models.DtoModels;

namespace Qinshift.Class04.Controllers {
	[Route("courses")]
	public class CourseController : Controller {
		public IActionResult Index() {
			var courses = InMemoryDatabase.Courses;
			var coursesList = new List<CoursesWithStudentsDTO>();

			foreach(var course in courses){
				var students = InMemoryDatabase.Students
					.Where(student => student.ActiveCourse.Id == course.Id)
					.Select(student => new StudentDTO {
						FullName = student.FirstName + " " + student.LastName
					});
				coursesList.Add(new CoursesWithStudentsDTO {
					Id = course.Id,
					Name = course.Name,
					Students = students.ToList()
				});
			}

			return View(coursesList);
		}
	}
}
