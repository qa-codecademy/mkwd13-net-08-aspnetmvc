using Qinshift.Models.Database;
using Qinshift.Models.Models.DomainModels;
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

            return mappedStudents;
        }
    }
}
