using Class02_ControllersActionsRouting.Models;
using Microsoft.AspNetCore.Mvc;

namespace Qinshift.Asp.Net.Mvc.Class02.Controllers.Controllers {
	// Atribute routing examples
	[Route("students")]
	public class StudentController : Controller {
		//This is going to be our data source
		//In Real-Time you will get the data from the database
		private List<Student> _students = new List<Student>
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
				FirstName = "Jill",
				LastName = "Jilski",
				DateOfBirth = DateTime.Now.AddYears(-37)
			},
			new Student()
			{
				Id = 3,
				FirstName = "John",
				LastName = "Doe",
				DateOfBirth = DateTime.Now.AddYears(-45)
			},
			new Student()
			{
				Id = 4,
				FirstName = "Jane",
				LastName = "Doe",
				DateOfBirth = DateTime.Now.AddYears(-17)
			},
		};

		public string GetStudentName() {
			return _students.First().FirstName;
		}

		// without route parameters
		[Route("all")]
		[HttpGet("all")]
		public List<Student> GetStudents() {
			return _students;
		}

		// Add route parameter without constraint
		[Route("{id}")]
		[HttpGet("{id}")] // Other way to use attribute routing
		public Student GetStudentById(int id) {
			return _students.FirstOrDefault(x => x.Id == id);
		}

		// Add route parameter with constraint
		[Route("byId/constraint/{id:int}")]
		public Student GetStudentByIdWithConstraint(int id) {
			return _students.FirstOrDefault(x => x.Id == id);
		}

		// Add route parameter with default value 
		[Route("byId/default/{id}")]
		public Student GetStudentByIdWithDefaultValue(int id = 1) {
			return _students.FirstOrDefault(x => x.Id == id);
		}

		// Add multiple route parameters
		[Route("{id}/{name}")]
		public Student GetStudentByIdAndNameMultipleParams(int id, string name) {
			return _students.FirstOrDefault(x => x.Id == id && x.FirstName == name);
		}
	}
}
