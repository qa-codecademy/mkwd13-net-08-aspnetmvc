namespace Class04.Models.DtoModel
{
    public class StudentWithCourseDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string NameOfCourse { get;set; }

        public StudentWithCourseDto(int id, string fName,string lName, DateTime dateOfBirth, string courseName) 
        {
            Id = id;
            FullName = $"{fName} {lName}";
            NameOfCourse = courseName;
            Age = DateTime.Now.Year - dateOfBirth.Year;
        }
    }
}
