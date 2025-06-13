using Qinshift.Models.Models.DomainModels;

namespace Qinshift.Models.Database
{
    public static class InMemoryDb
    {
        public static List<Student> Students { get; set; }
        public static List<Course> Courses { get; set; }

        static InMemoryDb()
        {
            LoadCourses();
            LoadStudents();
        }

        private static void LoadStudents()
        {
            Students = new List<Student>
            {
                new()
                {
                    Id = 1,
                    FirstName = "Bob",
                    LastName = "Bobsky",
                    DateOfBirth = DateTime.Now.AddYears(-23).AddDays(23),
                    ActiveCourse = Courses[3]
                },
                new()
                {
                    Id = 2,
                    FirstName = "Jill",
                    LastName = "Jillsky",
                    DateOfBirth = DateTime.Now.AddYears(-37).AddDays(12),
                    ActiveCourse = Courses[2]
                },
                new()
                {
                    Id = 3,
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = DateTime.Now.AddYears(-30).AddDays(-23),
                    ActiveCourse = Courses[1]
                },
                new()
                {
                    Id = 4,
                    FirstName = "Jane",
                    LastName = "Doe",
                    DateOfBirth = DateTime.Now.AddYears(-29).AddDays(-24),
                    ActiveCourse = Courses[3]
                }

            };
        }

        private static void LoadCourses()
        {
            Courses = new List<Course>
            {
                new Course{ Id = 1, Name = "C# Basic", NumberOfClasses = 40 },
                new Course{ Id = 2, Name = "C# Advanced", NumberOfClasses = 60 },
                new Course{ Id = 3, Name = "Database development and design", NumberOfClasses = 28 },
                new Course{ Id = 4, Name = "ASP.NET MVC", NumberOfClasses = 40 },
            };
        }
    }
}
