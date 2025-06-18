using Microsoft.AspNetCore.Mvc;
using Qinshift.ViewsPartTwo.Database;
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
    }
}
