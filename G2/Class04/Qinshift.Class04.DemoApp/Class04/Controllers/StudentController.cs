using Class04.Models.DtoModel;
using Class04.Services;
using Microsoft.AspNetCore.Mvc;

namespace Class04.Controllers
{
    [Route("[Controller]")]
    public class StudentController : Controller
    {
        private readonly StudentService _studentService;

        public StudentController()
        {
            _studentService = new StudentService();
        }

        //[HttpGet("getAllStudents")]
        public IActionResult GetAllStudents()
        {
            List<StudentWithCourseDto> students = _studentService.GetAllStudents();

            return View(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id) 
        {
            StudentWithCourseDto student = _studentService.GetStudentById(id);

            if (student == null) 
            {
                return RedirectToAction("Error", "Home");
            }

            return View(student);
        }

    }
}
