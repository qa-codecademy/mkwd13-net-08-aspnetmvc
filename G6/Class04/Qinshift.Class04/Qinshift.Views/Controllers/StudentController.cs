using Microsoft.AspNetCore.Mvc;
using Qinshift.Views.Database;
using Qinshift.Views.Models.Domain;
using Qinshift.Views.Models.ViewModels;

namespace Qinshift.Views.Controllers
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
                FullName = s.GetFullName(),
                Age = DateTime.Now.Year - s.DateOfBirth.Year,
                ActiveCourseName = s.ActiveCourse.Name
            }).ToList();

            // 3) Send the mapped objects to the view
            return View(mappedStudents);
        }

        // /student/GetStudentById/1
        public IActionResult GetStudentById(int id)
        {
            Student student = InMemoryDb.Students.FirstOrDefault(s => s.Id == id);

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
    }
}
