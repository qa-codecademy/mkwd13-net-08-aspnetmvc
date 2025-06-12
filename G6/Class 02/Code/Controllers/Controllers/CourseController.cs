using Controllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.Controllers
{
    public class CourseController : Controller
    {
        private List<Course> courses = new List<Course>()
        {
            new Course() { Id = 1, Name = "CSharp Basic", NumberOfClasses = 10},
            new Course() { Id = 2, Name = "CSharp Advanced", NumberOfClasses = 15},
            new Course() { Id = 3, Name = "Database development and design", NumberOfClasses = 7},
            new Course() { Id = 4, Name = "MVC", NumberOfClasses = 10},
        };

        public JsonResult GetAllCourses()
        {
            return Json(courses); //this way we return a json from this action
        }

        public IActionResult GetCourseById(int id)
        {
            return Json(courses.FirstOrDefault(x => x.Id == id));
        }

        public string GetCourse(int id)
        {
            return courses.FirstOrDefault(x => x.Id == id)?.Name;
        }

        public IActionResult GetCourseByName(string name)
        {
            return Json(courses.FirstOrDefault(x => x.Name == name));
        }

        public IActionResult GetCourseByIdAndByName(int id, string name)
        {
            var course = courses.FirstOrDefault(x => x.Id == id && x.Name == name);
            return Json(course);
        }
    }
}
