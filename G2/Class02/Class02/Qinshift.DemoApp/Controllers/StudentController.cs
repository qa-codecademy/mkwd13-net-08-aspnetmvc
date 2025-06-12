using Microsoft.AspNetCore.Mvc;
using Qinshift.DemoApp.Models;

namespace Qinshift.DemoApp.Controllers
{
    //[Route("students/[Action]")]
    [Route("students")]
    public class StudentController : Controller
    {
        private List<Student> _students = new List<Student>()
        {
            new() {Id=1, FirstName="Bob", LastName="Bobsky"},
            new() {Id=2, FirstName="Jill", LastName="Jillsky"},
            new() {Id=3, FirstName="Ted", LastName="Tedsky"}
        };

        [Route("getAllStudents")]
        public IActionResult GetAll()
        {
            return Json(_students);
        }

        [HttpGet("getAll")]
        public IActionResult GetStudents() {
            return Json(_students);
        }

        [Route("{id}")]
        public Student GetById(int id)
        {
            return _students.SingleOrDefault(x => x.Id == id);
        }

        [HttpGet("getStudentById/{id}")]
        public Student GetStudentById(int id)
        {
            return _students.SingleOrDefault(x=>x.Id == id);
        }

        [HttpGet("getStudentByIdWithConstraint/{id:int}")]
        public Student GetStudentByIdWithConstraint(int id) {
            return _students.SingleOrDefault(x => x.Id == id);
        }

        //Old way
        //public JsonResult Test()
        //{
        //    return Json(_students);
        //}

        //public ViewResult TestView()
        //{
        //    return View();
        //}

        //public ActionResult Test1()
        //{
        //    return Json(_students);
        //}


    }
}
