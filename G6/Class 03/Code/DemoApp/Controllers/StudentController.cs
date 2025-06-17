using DemoApp.Database;
using DemoApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    public class StudentController : Controller
    {
        private StudentService _studentService;

        public StudentController()
        {
            _studentService = new StudentService(); //we need an instance of the service so that we can call the methods 
        }

        //Bad practice - Avoid accessing the db and using domain models in the controller actions
        public IActionResult GetAllStudents()
        {
            return Json(StaticDb.Students);
        }

        public IActionResult GetStudentById(int id) {
        
            var student = _studentService.GetStudentById(id); //avoid using domain models in the controller actions
            if(student != null)
            {
                return Json(student);
            }
            return NotFound();  
        }

        public IActionResult GetStudentDetails(int id)
        {
            var studentDetails = _studentService.GetStudentWithCourse(id); //here the service returns StudentWithCourseDto? so our controller does not have a direct connection with the db nor with the domain model
            if(studentDetails != null )
            {
                return Json(studentDetails);
            }
            return Content("Student not found");
        }
    }
}
