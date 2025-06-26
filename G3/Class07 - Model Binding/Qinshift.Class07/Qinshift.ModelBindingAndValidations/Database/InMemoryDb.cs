using Qinshift.ModelBindingAndValidations.Models.Domain;

namespace Qinshift.ModelBindingAndValidations.Database
{
    public static class InMemoryDb
    {
        public static List<Student> Students { get; set; }
        static InMemoryDb()
        {
            LoadStudents();
        }

        private static void LoadStudents()
        {
            Students = new List<Student>
            {
                new Student()
                {
                    Id = 1,
                    FirstName = "Bob",
                    LastName = "Bobski",
                    DateOfBirth = DateTime.Now.AddYears(-27).AddDays(-5).AddMonths(3),
                    Email = "bob@bobsky.com",
                    PhoneNumber = "+389 78 123 123"
                },
                new Student()
                {
                    Id = 2,
                    FirstName = "Jill",
                    LastName = "Jilski",
                    DateOfBirth = DateTime.Now.AddYears(-37).AddDays(5),
                    Email = "jill@jillsky.com",
                    PhoneNumber = "+389 78 123 123"
                },
                new Student()
                {
                    Id = 3,
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = DateTime.Now.AddYears(-45).AddMonths(-2),
                    Email = "john@doe.com",
                    PhoneNumber = "+389 70 123 123"
                },
                new Student()
                {
                    Id = 4,
                    FirstName = "Jane",
                    LastName = "Doe",
                    DateOfBirth = DateTime.Now.AddYears(-17).AddDays(12),
                    Email = "jane@doe.com",
                    PhoneNumber = "+389 78 231 232"
                },
            };
        }
    }
}
