namespace Qinshift.Class04.Models.DtoModels {
	public class StudentWithCourseDto {
		public StudentWithCourseDto(
			int id, string firstName, 
			string lastName, DateTime dateOfBirth,
			int courseId, string courseName) 
		{
			Id = id;
			FullName = string.Format("{0} {1}", firstName, lastName);
			CourseId = courseId;
			NameOfCourse = courseName;
			Age = DateTime.Now.Year - dateOfBirth.Year;
		}

		public int Id { get; set; }
		public string FullName { get; set; }
		public int Age { get; set; }
		public int CourseId { get; set; }
		public string NameOfCourse { get; set; }
	}
}
