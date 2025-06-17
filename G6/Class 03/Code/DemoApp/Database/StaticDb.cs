using DemoApp.Models.Domain;

namespace DemoApp.Database
{
    public static class StaticDb
    {
        static StaticDb()
        {
            LoadCourses();
            LoadStudents();
        }
        public static List<Student> Students { get; set; }
        public static List<Course> Courses { get; set; }

        private static void LoadCourses()
        {
            Courses = new List<Course>()
            {
                new Course() {Id = 1, Name = "CSharp basic", NumberOfClasses = 10},
                new Course() {Id = 2, Name = "CSharp advanced", NumberOfClasses = 15},
                new Course() {Id = 3, Name = "Database development and design", NumberOfClasses = 7},
                new Course() {Id = 4, Name = "ASP .NET Core MVC", NumberOfClasses = 10},
            };
        }
        private static void LoadStudents()
        {
            Students = new List<Student>()
            {
                new()
                {
                    Id = 1,
                    FirstName = "Petko",
                    LastName = "Petkovski",
                    DateOfBirth = DateTime.Now.AddYears(-25),
                    ActiveCourse = Courses[0]
                },
                new()
                {
                    Id = 2,
                    FirstName = "Marko",
                    LastName = "Markovski",
                    DateOfBirth = DateTime.Now.AddYears(-35),
                    ActiveCourse = Courses[1]
                },
                new()
                {
                    Id = 3,
                    FirstName = "Nikola",
                    LastName = "Nikolovski",
                    DateOfBirth = DateTime.Now.AddYears(-20),
                    ActiveCourse = Courses[0]
                },
                new()
                {
                    Id = 4,
                    FirstName = "Stefan",
                    LastName = "Stefanovski",
                    DateOfBirth = DateTime.Now.AddYears(-29),
                    ActiveCourse = Courses[1]
                }
            };
        }
    }
}
