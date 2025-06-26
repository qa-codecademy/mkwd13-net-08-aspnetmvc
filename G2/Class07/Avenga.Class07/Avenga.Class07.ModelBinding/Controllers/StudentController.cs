using Avenga.Class07.ModelBinding.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Avenga.Class07.ModelBinding.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<StudentDto> students = new()
            {
                new StudentDto
                {
                    FullName = "Bob Bobsky",
                    Age = 33
                },
                new StudentDto
                {
                    FullName = "Jill Wayne",
                    Age = 20
                },
                new StudentDto
                {
                    FullName = "John Doe",
                    Age = 40
                },
                new StudentDto
                {
                    FullName = "Martin Panovski",
                    Age = 31
                },
            };
            return View(students);
        }
    }
}
