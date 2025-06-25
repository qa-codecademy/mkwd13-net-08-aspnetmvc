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

        public IActionResult Details(int studentId)
        {
            var studentDb = InMemoryDb.Students.FirstOrDefault(s => s.Id == studentId);
            if (studentDb is null)
            {
                return NotFound();
            }

            var studentDetailsVM = studentDb.ToStudentDetailsVM();
            return View(studentDetailsVM);
        }

        // /student/create
        //[HttpGet("student/add")]
        public IActionResult Create()
        {
            CreateStudentViewModel createStudentViewModel = new();
            return View(createStudentViewModel);
        }

        [HttpPost]
        public IActionResult Create(CreateStudentViewModel model)
        {
            var student = model.ToStudent();
            InMemoryDb.Students.Add(student);
            TempData["FormMessage"] = "Student succesfully created!";
            return RedirectToAction("Index");
        }

    }
}
