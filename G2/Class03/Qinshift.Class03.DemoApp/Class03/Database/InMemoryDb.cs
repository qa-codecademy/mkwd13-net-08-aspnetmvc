using Class03.Models.Entities;
using System.Runtime.CompilerServices;

namespace Class03.Database
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
            Students = new List<Student>()
            {
                new Student()
                {
                    Id = 1,
                    FirstName = "Bob",
                    LastName = "Bobsky",
                    DateOfBirth = DateTime.Now.AddYears(-27),
                    ActiveCourse = Courses[1]
                },
                                new Student()
                {
                    Id = 2,
                    FirstName = "Jill",
                    LastName = "Jillsky",
                    DateOfBirth = DateTime.Now.AddYears(-20),
                    ActiveCourse = Courses[0]
                },
                                              new Student()
                {
                    Id = 3,
                    FirstName = "Ana",
                    LastName = "Anaski",
                    DateOfBirth = DateTime.Now.AddYears(-20),
                    ActiveCourse = Courses[2]
                }
            };

        }

        private static void LoadCourses()
        {
            Courses = new List<Course>()
            {
                new Course() { 
                    Id = 1,
                    Name = "C# Basic",
                    NumberOfClasses = 10
                },
                new Course() {
                    Id = 2,
                    Name = "C# Adv",
                    NumberOfClasses = 15
                },
                new Course() {
                    Id = 3,
                    Name = "ASP.NET Core MVC",
                    NumberOfClasses = 10
                }
            };
        }
    }
}
