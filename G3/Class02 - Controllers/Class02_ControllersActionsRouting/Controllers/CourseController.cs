using Class02_ControllersActionsRouting.Models;
using Microsoft.AspNetCore.Mvc;

namespace Class02_ControllersActionsRouting.Controllers {
	public class CourseController : Controller {
		private List<Course> _courses = new List<Course>()
		{
			new Course() { Id = 1, Name = "CSharp Basic", NumberOfClasses = 10},
			new Course() { Id = 2, Name = "CSharp Advanced", NumberOfClasses = 5},
			new Course() { Id = 3, Name = "Database development and design", NumberOfClasses = 8},
			new Course() { Id = 4, Name = "ASP.NET MVC", NumberOfClasses = 10}
		};

		public JsonResult GetAllCourses() 
		{
			return Json(_courses);
		}

		public IActionResult GetCourseById(int id) 
		{
			return Json(_courses.FirstOrDefault(course => course.Id == id));
		}

		public IActionResult GetCourseByName(string name) {
			return Json(_courses.FirstOrDefault(course => course.Name == name));
		}

		public string GetCourse (int id) 
		{
			return _courses.FirstOrDefault(course => course.Id == id).Name;
		}
		public IActionResult GetCourseNameByIdOrName(int id, string name) 
		{
			var course = _courses.FirstOrDefault(course => course.Id == id);
			if (course == null) 
			{
				course = _courses.FirstOrDefault(course => course.Name == name);
				return Json(course);
			}else 
			{
				return Json(course);
			}
		}
	}
}
