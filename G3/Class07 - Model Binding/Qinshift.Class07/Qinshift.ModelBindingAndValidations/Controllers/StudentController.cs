using Microsoft.AspNetCore.Mvc;
using Qinshift.ModelBindingAndValidations.Database;
using Qinshift.ModelBindingAndValidations.Models.Domain;
using Qinshift.ModelBindingAndValidations.Models.ViewModels;

namespace Qinshift.ModelBindingAndValidations.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            List<StudentViewModel> students = InMemoryDb.Students.Select(s => new StudentViewModel
            {
                Id = s.Id,
                FullName = s.GetFullName(),
                Age = DateTime.Now.Year - s.DateOfBirth.Year,
                Email = s.Email
            }).ToList();

            ViewData["CurrentDate"] = DateTime.Now.ToShortDateString();
            ViewBag.WelcomeMessage = "Welcome to the Student Management System";

            return View(students);
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
            var student = new Student
            {
                Id = InMemoryDb.Students.Count + 1,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                DateOfBirth = model.DateOfBirth,
                PhoneNumber = model.PhoneNumber
            };
            InMemoryDb.Students.Add(student);
            TempData["FormMessage"] = "Student succesfully created!";
            return RedirectToAction("Index");
        }

    }
}
