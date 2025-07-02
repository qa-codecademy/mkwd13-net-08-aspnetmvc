using Avenga.EntityFramework.Database;
using Avenga.EntityFramework.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Avenga.EntityFramework.Controllers
{
    public class StudentController : Controller
    {
        // Don't you ever try to inject dbcontext in controller constructor ! ! !
        // Only for demo purpose
        private readonly AcademyDbContext _context;

        public StudentController(AcademyDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var students = _context.Students
                                    .Include(x => x.ActiveCourse)
                                    .ToList();
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Student model)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(model);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
