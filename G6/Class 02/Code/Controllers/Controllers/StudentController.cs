using Controllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.Controllers
{
    //Atribute routing examples
    [Route("students")]
    public class StudentController : Controller
    {
        private List<Student> students = new List<Student>()
       {
           new Student()
           {
               Id = 1,
               FirstName = "Bob",
               LastName = "Bobski",
               DateOfBirth = DateTime.Now.AddYears(-27)
           },
           new Student()
           {
               Id = 2,
               FirstName = "Petko",
               LastName = "Petkovski",
               DateOfBirth = DateTime.Now.AddYears(-37)
           },
           new Student()
           {
               Id = 3,
               FirstName = "Marko",
               LastName = "Markovski",
               DateOfBirth = DateTime.Now.AddYears(-24)
           },
       };

        public string GetStudentFirstName()
        {
            return students.First().FirstName;
        }

        //AmbiguousMatchException: The request matched multiple endpoints.
        //public string GetStudentLastName()
        //{
        //    return students.First().LastName;
        //}

        [Route("lastname")]
        public string GetStudentLastName()
        {
            return students.First().LastName;
        }

        //without route params
        //[Route("all")] //standard way by using the route atribute
        [HttpGet("all")] //another way we can specify the route is by combining it with the http atribute
        public List<Student> GetAll()
        {
            return students;
        }

        //with route params
        [HttpGet("{id}")]
        public Student GetStudentById (int id)
        {
            return students.FirstOrDefault(x => x.Id == id);
        }

        [Route("byId/{id}")]
        public Student GetStudentByIdWithRouteText(int id)
        {
            return students.FirstOrDefault(x => x.Id == id);
        }

        //we are adding a constraint that the type of the id must be int
        [Route("byId/constraint/{id:int}")]
        public Student GetStudentByIdWithConstraint(int id)
        {
            return students.FirstOrDefault(x => x.Id == id);
        }

        //add multiple route params
        [Route("{id}/{name}")]
        public Student GetStudentByIdAndNameMultipleParams(int id, string name)
        {
            return students.FirstOrDefault(x => x.Id == id && x.FirstName == name);
        }
    }
}
