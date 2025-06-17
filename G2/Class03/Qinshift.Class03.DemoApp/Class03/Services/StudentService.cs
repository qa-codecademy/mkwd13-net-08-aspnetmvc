using Class03.Database;
using Class03.Models.DtoModels;
using Class03.Models.Entities;

namespace Class03.Services
{
    public class StudentService
    {
        public StudentWithCourseDto GetStudentWithCourse(int id)
        {
            Student student = InMemoryDb.Students.SingleOrDefault(x => x.Id == id);

            if (student == null) 
            {
                return null;
            }

            StudentWithCourseDto studentWithCourse = new StudentWithCourseDto()
            {
                Id = student.Id,
                FullName = $"{student.FirstName} {student.LastName}",
                NameOfCourse = student.ActiveCourse.Name,
                Age = DateTime.Now.Year - student.DateOfBirth.Year
            };

            return studentWithCourse;
        }

        public List<ListAllStudentsDto> GetAllStudents() 
        {
            return InMemoryDb.Students.Select(student =>
            new ListAllStudentsDto
            {
                FullName = $"{student.FirstName} {student.LastName}"
            }).ToList();
        }
    }
}
