using DemoApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    [Route("courses")]
    public class CourseController : Controller
    {
        private CourseService _courseService;

        public CourseController()
        {
            _courseService = new CourseService();
        }

        [HttpGet("getCourses")]
        public IActionResult GetCourses()
        {
            var courses = _courseService.GetCoursesWithMoreThanNineClasses();
            if (courses != null && courses.Any())
            {
                return View(courses); //we pass our view model to our view, so that we can show the data that was returned
            }

            return Content("No courses available");
        }
    }
}
