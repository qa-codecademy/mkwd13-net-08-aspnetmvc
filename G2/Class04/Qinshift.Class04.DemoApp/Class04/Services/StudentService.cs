using Class04.Database;
using Class04.Models.DtoModel;
using Class04.Models.Entites;

namespace Class04.Services
{
    public class StudentService
    {
        public List<StudentWithCourseDto> GetAllStudents()
        {
            List<StudentWithCourseDto> students = InMemoryDb.Students.Select(x => new StudentWithCourseDto(x.Id, x.FirstName, x.LastName, x.DateOfBirth, x.ActiveCourse.Name)).ToList();

            return students;
            //List<StudentWithCourseDto> students = InMemoryDb.Students.Select(x => new StudentWithCourseDto
            //{
            //    Id = x.Id,
            //    FullName = $"{x.FirstName} {x.LastName}"
            //}().ToList();
        }

        public StudentWithCourseDto GetStudentById(int id)
        {
            Student student = InMemoryDb.Students.SingleOrDefault(x => x.Id == id);

            if (student == null)
            {
                return null;
            }

            return new StudentWithCourseDto(student.Id, student.FirstName, student.LastName, student.DateOfBirth, student.ActiveCourse.Name);

        }
    }
}
