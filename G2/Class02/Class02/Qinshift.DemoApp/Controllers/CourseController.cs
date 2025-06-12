using Microsoft.AspNetCore.Mvc;
using Qinshift.DemoApp.Models;

namespace Qinshift.DemoApp.Controllers
{
    public class CourseController : Controller
    {
        //CONVENTIONAL ROUTING
        private List<Course> _courses = new List<Course>()
        {
            new() {Id=1, Name="Basic Csharp", NumberOfClasses=10},
            new() {Id=2, Name="Advanced Csharp", NumberOfClasses=15},
            new() {Id=3, Name="ASP.NET CORE MVC", NumberOfClasses=10},
            new() {Id=4, Name="ASP.NET CORE WEB API", NumberOfClasses=15}
        };

        //localhost:port/course/getAllCourses
        //public JsonResult GetAllCourses()
        //{
        //    return Json( _courses );
        //}

        [HttpGet]//localhost:port/course/getAllCourses
        public IActionResult GetAllCourses()
        {
            return Json( _courses );
        }

        public IActionResult GetCourseById(int id)
        {
            return Json( _courses.SingleOrDefault(x=>x.Id == id));
        }

        public IActionResult GetCourseByIdOrName(int id, string name)
        {
            Course course = _courses.FirstOrDefault(x => x.Id == id);

            if(course == null)
            {
                course = _courses.FirstOrDefault(x => x.Name == name);

                if (course == null) return NoContent();

                return Json(course);
            }
            else
            {
                return Json(course);
            }
        }
    }
}
