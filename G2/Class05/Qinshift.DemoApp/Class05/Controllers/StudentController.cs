using Class05.Database;
using Class05.Models.Entites;
using Class05.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Class05.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult GetAllStudents()
        {
            List<StudentVM> students = InMemoryDb.Students.Select(x => new StudentVM
            {
                Id = x.Id,
                FullName = $"{x.FirstName} {x.LastName}",
                Age = DateTime.Now.Year - x.DateOfBirth.Year,
                ActiveCourseName = x.ActiveCourse.Name
            }).ToList();
            return View(students);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            CreateStudentVM createStudentVM = new();
            createStudentVM.FirstName = "Martin";
            createStudentVM.LastName = "Panovski";
            createStudentVM.Courses = InMemoryDb.Courses.Select(x => new CourseOptionVM
            {
                Id= x.Id,
                Name = x.Name,
            }).ToList();

            return View(createStudentVM);
        }

        [HttpPost("create")]
        public IActionResult Create(CreateStudentVM createStudentVM)
        {
            Student student = new Student
            {
                Id = InMemoryDb.Students.Count + 1,
                FirstName = createStudentVM.FirstName,
                LastName = createStudentVM.LastName,
                DateOfBirth = createStudentVM.DateOfBirth,
                ActiveCourse = InMemoryDb.Courses.FirstOrDefault(x => x.Id == createStudentVM.ActiveCourseId)
            };

            InMemoryDb.Students.Add(student);
            return RedirectToAction("GetAllStudents");
        }
    }
}
