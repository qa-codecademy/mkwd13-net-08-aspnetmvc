using Class03.Models.DtoModels;
using Class03.Services;
using Microsoft.AspNetCore.Mvc;

namespace Class03.Controllers
{
    [Route("students")]
    public class StudentController : Controller
    {
        private StudentService _studentService;

        public StudentController()
        {
            _studentService = new StudentService();
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id) 
        {
            StudentWithCourseDto student = _studentService.GetStudentWithCourse(id);

            if (student == null) 
            {
                return Content("Student not found");
            }

            return Json(student);
        }

        [HttpGet("getAllStudents")]
        public IActionResult GetAllStudents() 
        {
            List<ListAllStudentsDto> students = _studentService.GetAllStudents();
            return Json(students);
        }


    }
}
