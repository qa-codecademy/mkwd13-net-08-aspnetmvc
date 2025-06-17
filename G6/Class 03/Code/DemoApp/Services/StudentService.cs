using DemoApp.Database;
using DemoApp.Models.Domain;
using DemoApp.Models.DTOs;

namespace DemoApp.Services
{
    public class StudentService
    {
        public Student GetStudentById(int id)
        {
            return StaticDb.Students.SingleOrDefault(x => x.Id == id); //when accessing the db we are working with domain models
        }

        public StudentWithCourseDto GetStudentWithCourse(int id)
        {
            Student student = StaticDb.Students.SingleOrDefault(x => x.Id == id);

            if(student == null)
            {
                return null;
            }

            //we need to map the data from the domain model Student that we got from the db to our Dto model that our controller expects
            var studentWithCourse = new StudentWithCourseDto
            {
                Id = student.Id,
                FullName = $"{student.FirstName} {student.LastName}",
                Age = DateTime.Now.Year - student.DateOfBirth.Year,
                NameOfActiveCourse = student.ActiveCourse.Name
            };

            return studentWithCourse;
        }
    }
}
