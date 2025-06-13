using Microsoft.AspNetCore.Mvc;
using Qinshift.Models.Services;

namespace Qinshift.Models.Controllers
{
    //[Route("students")] // custom route name for our controller 
    [Route("[controller]/[action]")] // set routing to be "controllerName/actionName"
    public class StudentController : Controller
    {
        private readonly StudentService _studentService;

        public StudentController()
        {
            _studentService = new StudentService();
        }

        //[Route("all")] // /students/all (if using Route("students") for the controller)
        [HttpGet] // /student/getallstudents
        public IActionResult GetAllStudents()
        {
            var students = _studentService.GetAllStudents();

            //return View(students);
            // NOTE: Handling the ViewModels in the View, as well as creating Views will be discussed in the following lectures
            return Json(students);
        }
    }
}
