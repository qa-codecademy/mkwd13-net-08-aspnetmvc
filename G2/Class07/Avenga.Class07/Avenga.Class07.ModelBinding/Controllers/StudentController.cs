using Avenga.Class07.ModelBinding.Models.Dtos;
using Avenga.Class07.ModelBinding.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Avenga.Class07.ModelBinding.Controllers
{
    public class StudentController : Controller
    {

        private List<StudentDto> _students;

        public StudentController()
        {
            _students = new List<StudentDto>()
            {
                new StudentDto
                {
                    Id = 1,
                    FullName = "Bob Bobsky",
                    Age = 33
                },
                new StudentDto
                {
                    Id = 2,
                    FullName = "Jill Wayne",
                    Age = 20
                },
                new StudentDto
                {
                    Id = 3,
                    FullName = "John Doe",
                    Age = 40
                },
                new StudentDto
                {
                    Id = 4,
                    FullName = "Martin Panovski",
                    Age = 31
                }
            };
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View(_students);
        }

        public IActionResult Details([FromRoute]int id, [FromQuery]string fName, [FromQuery]string lName)
        {
            if(!string.IsNullOrEmpty(fName) || !string.IsNullOrEmpty(lName))
            {
                var studentByName = _students.FirstOrDefault(x => x.FullName == $"{fName} {lName}");
                return View(studentByName);
            }
            var student = _students.SingleOrDefault(x => x.Id == id);
            return View(student);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm]CreateStudentVM model)
        {
            if (ModelState.IsValid)
            {
                if(model.DateOfBirth > DateTime.Now)
                {
                    ModelState.AddModelError(string.Empty, "Date of birth cannot be in future.");
                    return View();
                }
                StudentDto student = new()
                {
                    Id = _students.Count + 1,
                    FullName = $"{model.FirstName} {model.LastName}",
                    Age = DateTime.Now.Year - model.DateOfBirth.Year
                };
                _students.Add(student);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
