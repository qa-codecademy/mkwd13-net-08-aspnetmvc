using ModelBinidingsAndDataAnnotations.Models.Domain;

namespace ModelBinidingsAndDataAnnotations.Database
{
    public static class StaticDb
    {
        public static List<Student> Students { get; set; }

        static StaticDb()
        {
            Students = new List<Student>()
            {
                new Student()
                {
                    Id = 1,
                    FirstName = "Petko",
                    LastName = "Petkovski",
                    DateOfBirth = DateTime.Now.AddYears(-31),
                    Email = "petkovskip@test.com",
                    PhoneNumber = "070123456"
                },
                new Student()
                {
                    Id = 2,
                    FirstName = "Marko",
                    LastName = "Markovski",
                    DateOfBirth = DateTime.Now.AddYears(-25),
                    Email = "markom@test.com",
                    PhoneNumber = "070456321"
                },
                new Student()
                {
                    Id = 3,
                    FirstName = "Nikola",
                    LastName = "Nikolovski",
                    DateOfBirth = DateTime.Now.AddYears(-28),
                    Email = "nikolan@test.com",
                    PhoneNumber = "070789456"
                },
                new Student()
                {
                    Id = 4,
                    FirstName = "Stefan",
                    LastName = "Stefanovski",
                    DateOfBirth = DateTime.Now.AddYears(-22),
                    Email = "stefans@test.com",
                    PhoneNumber = "070987654"
                },
            };
        }
    }
}
