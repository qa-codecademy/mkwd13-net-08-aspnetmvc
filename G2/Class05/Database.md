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
            ActiveCourse = Courses[1]
        },
        new Student()
        {
            Id = 2,
            FirstName = "Jill",
            LastName = "Jilski",
            DateOfBirth = DateTime.Now.AddYears(-37).AddDays(5),
            ActiveCourse = Courses[2]
        },
        new Student()
        {
            Id = 3,
            FirstName = "John",
            LastName = "Doe",
            DateOfBirth = DateTime.Now.AddYears(-45).AddMonths(-2),
            ActiveCourse = Courses[3]
        },
        new Student()
        {
            Id = 4,
            FirstName = "Jane",
            LastName = "Doe",
            DateOfBirth = DateTime.Now.AddYears(-17).AddDays(12),
            //ActiveCourse = Courses[3]
        },
    };
}

private static void LoadCourses()
{
    Courses = new List<Course>()
    {
        new() { Id = 1, Name = "C# Basic", NumberOfClasses = 40 },
        new() { Id = 2, Name = "C# Advanced", NumberOfClasses = 60 },
        new() { Id = 3, Name = "Database development and design", NumberOfClasses = 28 },
        new() { Id = 4, Name = "ASP.NET MVC", NumberOfClasses = 40 },
        new() { Id = 5, Name = "ASP.NET Web Api", NumberOfClasses = 60 }
    };
}