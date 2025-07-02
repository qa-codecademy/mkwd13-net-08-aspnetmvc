using Avenga.EntityFramework.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Avenga.EntityFramework.Database
{
    public class AcademyDbContext : DbContext
    {
        // 1.First add the constructor with the needed DbContextOptions passed
        //   to its parent constructor
        public AcademyDbContext(DbContextOptions options) : base(options) { }



        // 2. Configure which models will be translated as tables in the DB

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }


        // 3. Override the OnModelCreating() method, so that you will
        //    configure the relations, the data that needs to be seeded upfront
        //    and also the rules for some of the properties of the domain models
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            List<Course> courses = new()
            {
                new Course
                {
                    Id = 1,
                    Name = "C# Basic",
                    NumberOfClasses = 10
                },
                new Course
                {
                    Id = 2,
                    Name = "C# Advanced",
                    NumberOfClasses = 15
                }
            };
            
            List<Student> students = new()
            {
                new Student
                {
                    Id = 1,
                    FirstName = "Bob",
                    LastName = "Bobsky",
                    DateOfBirth = DateTime.Now.AddYears(-23),
                    ActiveCourseId = 1
                },
                new Student
                {
                    Id = 2,
                    FirstName = "Jill",
                    LastName = "Wayne",
                    DateOfBirth = DateTime.Now.AddYears(-28),
                    ActiveCourseId = 2
                },
                new Student
                {
                    Id = 3,
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = DateTime.Now.AddYears(-18),
                    ActiveCourseId = 1
                },
            };


            // Fluent API configuration
            //modelBuilder
            //    .Entity<Course>()
            //    .HasMany(x => x.Students)
            //    .WithOne(x => x.ActiveCourse)
            //    .HasForeignKey(x => x.ActiveCourseId);

            modelBuilder
                .Entity<Course>()
                .HasData(courses);

            modelBuilder
                .Entity<Student>()
                .HasData(students);
        }

    }
}
