using Microsoft.AspNetCore.Mvc;
using Qinshift.ModelBindingAndValidations.Database;
using Qinshift.ModelBindingAndValidations.Helpers;
using Qinshift.ModelBindingAndValidations.Models.ViewModels;

namespace Qinshift.ModelBindingAndValidations.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            List<StudentViewModel> students = InMemoryDb.Students.Select(s => s.MapToStudentViewModel()).ToList();

            ViewData["CurrentDate"] = DateTime.Now.ToShortDateString();
            ViewBag.WelcomeMessage = "Welcome to the Student Management System";

            return View(students);
        }

        // =====> Using [FromRoute] binding attribute
        // NOTE: The route parameter must be specified in the route definition
        // https://localhost:7048/Student/Details/3
        [HttpGet("student/details/{studentId:int}")]
        public IActionResult Details([FromRoute] int studentId)
        {
            var studentDb = InMemoryDb.Students.FirstOrDefault(s => s.Id == studentId);
            if (studentDb is null)
            {
                return NotFound();
            }

            var studentDetailsVM = studentDb.ToStudentDetailsVM();  
            return View(studentDetailsVM);
        }

        // =====> Using [FromQuery] binding attribute

        // https://localhost:7048/Student/FilterBy?fullName=John%20Doe&age=45

        // #==> Example 1: Explicitly using the [FromQuery] attribute

        //public IActionResult FilterBy([FromQuery] string fullName, [FromQuery] int age)
        //{
        //    var student = InMemoryDb.Students.FirstOrDefault(s => s.GetFullName() == fullName && (DateTime.Now.Year - s.DateOfBirth.Year) == age);
        //    if (student is null)
        //    {
        //        return NotFound();
        //    }
        //    return View("Details", student.ToStudentDetailsVM());
        //}

        // #==> Example 2: Leave out the [FromQuery] attribute (they are sent as query parameters by default)

        //public IActionResult FilterBy(string fullName, int age)
        //{
        //    var student = InMemoryDb.Students.FirstOrDefault(s => s.GetFullName() == fullName && (DateTime.Now.Year - s.DateOfBirth.Year) == age);
        //    if (student is null)
        //    {
        //        return NotFound();
        //    }
        //    return View("Details", student.ToStudentDetailsVM());
        //}

        // #==> Example 3: Using custom model with it's properties being sent as query parameters (best way when working with multiple query parameters) 

        // https://localhost:7048/Student/FilterBy?fullName=Bob%20Bobski&age=27
        public IActionResult FilterBy([FromQuery] StudentFilterViewModel filter)
        {
            var student = InMemoryDb.Students.FirstOrDefault(s => s.GetFullName() == filter.FullName && (DateTime.Now.Year - s.DateOfBirth.Year) == filter.Age);
            if (student is null)
            {
                return NotFound();
            }
            return View("Details", student.ToStudentDetailsVM());
        }

        // /student/create
        //[HttpGet("student/add")]
        public IActionResult Create()
        {
            CreateStudentViewModel createStudentViewModel = new();
            return View(createStudentViewModel);
        }

        [HttpPost]
        // =====> Using [FromForm] binding attribute
        public IActionResult Create([FromForm] CreateStudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var student = model.ToStudent();
                InMemoryDb.Students.Add(student);
                TempData["FormMessage"] = "Student succesfully created!";
                return RedirectToAction("Index");
            }

            return View(model);
        }

    }
}
