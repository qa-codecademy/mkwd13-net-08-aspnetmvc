using Microsoft.AspNetCore.Mvc;
using Qinshift.ViewsPartTwo.Database;
using Qinshift.ViewsPartTwo.Models.Domain;
using Qinshift.ViewsPartTwo.Models.ViewModels;

namespace Qinshift.ViewsPartTwo.Controllers
{
    public class StudentController : Controller
    {
        // /student/index
        public IActionResult Index()
        {
            // 1) Get all students from db
            List<Student> studentsDb = InMemoryDb.Students;

            // 2) Map to corresponding View Model
            List<StudentViewModel> mappedStudents = studentsDb.Select(s => new StudentViewModel
            {
                Id = s.Id,
                FullName = s.GetFullName(),
                Age = DateTime.Now.Year - s.DateOfBirth.Year,
                ActiveCourseName = s.ActiveCourse?.Name ?? "No Course"
            }).ToList();

            ViewData["CurrentDate"] = DateTime.Now.ToShortDateString();
            ViewBag.WelcomeMessage = "Welcome to the Student Management System";
            ViewBag.HasManyStudents = mappedStudents.Count > 100;

            // 3) Send the mapped objects to the view
            return View(mappedStudents);
        }

        // /student/GetStudentById/1
        public IActionResult GetStudentById(int studentId)
        {
            Student student = InMemoryDb.Students.FirstOrDefault(s => s.Id == studentId);

            if (student is null)
            {
                return View();
            }

            StudentCourseViewModel mappedStudent = new StudentCourseViewModel
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Age = DateTime.UtcNow.Year - student.DateOfBirth.Year,
                CourseName = student.ActiveCourse.Name,
                NumberOfClasses = student.ActiveCourse.NumberOfClasses
            };

            return View(mappedStudent);
        }

        public IActionResult Create()
        {
            CreateStudentViewModel createStudentVM = new();
            createStudentVM.Courses = InMemoryDb.Courses.Select(c => new CourseOptionViewModel
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();

            return View(createStudentVM);
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
                ActiveCourse = InMemoryDb.Courses.FirstOrDefault(c => c.Id == model.ActiveCourseId)!
            };

            InMemoryDb.Students.Add(student);

            TempData["FormMessage"] = "Student successfully created!";

            return RedirectToAction("Index");
        }

    }
}
