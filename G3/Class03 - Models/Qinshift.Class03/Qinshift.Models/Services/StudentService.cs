using Qinshift.Models.Database;
using Qinshift.Models.Models.DomainModels;
using Qinshift.Models.Models.DtoModels;
using Qinshift.Models.Models.ViewModels;

namespace Qinshift.Models.Services
{
    public class StudentService
    {
        public List<StudentViewModel> GetAllStudents()
        {
            // 1. Get students from DB
            List<Student> studentsDb = InMemoryDb.Students;

            // 2. Validate 
            if (!studentsDb.Any())
            {
                return new List<StudentViewModel>();
            }

            // 3. Map (transform) the Domain model objects to ViewModel objects that contain only the necessery information
            List<StudentViewModel> mappedStudents = studentsDb
                .Select(s => new StudentViewModel
                {
                    Id = s.Id,
                    FullName = $"{s.FirstName} {s.LastName}",
                    Course = s.ActiveCourse.Name
                })
                .ToList();

            // 4. Return the mapped list 
            return mappedStudents;
        }

        public StudentWithCourseDto GetStudentWithActiveCourseById(int studentId)
        {
            // 1. Get student by id from db
            Student student = InMemoryDb.Students.FirstOrDefault(s => s.Id == studentId);

            // 2. Validate if student is null
            if (student is null)
            {
                return null;
            }

            // 3. Map (transform) the Domain model into Dto model containing only the needed information
            StudentWithCourseDto studentDto = new StudentWithCourseDto
            {
                Id = student.Id,
                FullName = $"{student.FirstName} {student.LastName}",
                Age = DateTime.Now.Year - student.DateOfBirth.Year,
                CourseName = student.ActiveCourse.Name
            };

            // 4. Return the mapped Dto model
            return studentDto;
        }

        // EXERCISE 01
        public StudentCourseDetailDto? GetStudentCourseDetail(int id)
        {
            var studentDb = InMemoryDb.Students.FirstOrDefault(s => s.Id == id);

            if (studentDb == null)
            {
                return null;
            }

            var studentCourseDto = new StudentCourseDetailDto
            {
                StudentId = studentDb.Id,
                FullName = studentDb.FirstName + " " + studentDb.LastName,
                CourseId = studentDb.ActiveCourse.Id,
                CourseName = studentDb.ActiveCourse.Name,
                NumberOfClasses = studentDb.ActiveCourse.NumberOfClasses,
            };

            return studentCourseDto;
        }
    }
}
