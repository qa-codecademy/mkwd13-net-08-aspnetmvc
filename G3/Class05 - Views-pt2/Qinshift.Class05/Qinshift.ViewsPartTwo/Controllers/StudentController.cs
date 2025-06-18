using Microsoft.AspNetCore.Mvc;
using Qinshift.ViewsPartTwo.Database;
using Qinshift.ViewsPartTwo.Models.Domain;
using Qinshift.ViewsPartTwo.Models.ViewModels;

namespace Qinshift.ViewsPartTwo.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            List<StudentViewModel> students = InMemoryDb.Students.Select(s => new StudentViewModel
            {
                Id = s.Id,
                FullName = s.GetFullName(),
                Age = DateTime.UtcNow.Year - s.DateOfBirth.Year,
                ActiveCourseName = s.ActiveCourse?.Name ?? "No Course"
            }).ToList();

            return View(students);
        }

        // /student/create
        public IActionResult Create()
        {
            CreateStudentViewModel createStudentViewModel = new();
            createStudentViewModel.Courses = InMemoryDb.Courses.Select(c => new CourseOptionViewModel
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();

            return View(createStudentViewModel);
        }

        [HttpPost]
        public IActionResult Create(CreateStudentViewModel model)
        {
            var student = new Student
            {
                Id = InMemoryDb.Students.Max(s => s.Id) + 1,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
                ActiveCourse = InMemoryDb.Courses.FirstOrDefault(c => c.Id == model.ActiveCourseId)
            };

            InMemoryDb.Students.Add(student);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int studentId)
        {
            return View();
        }
    }
}
