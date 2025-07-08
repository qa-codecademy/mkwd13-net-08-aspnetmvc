using Microsoft.EntityFrameworkCore;
using ToDoApp.Domain;

namespace ToDoApp.DataAccess
{
    //Defines and configures the db context for our entities
    public class ToDoAppDbContext : DbContext
    {
        //Define database tables
        //DbSet<T> is a collection of entities of type T that can be queried
        //It corresponds to a table in a db, where the properties are columns
        //here we are telling the db context that out of all our classes, only these three should be entities that will be tables in our db
        public DbSet<ToDo> ToDo { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Category> Category { get; set; }

        public ToDoAppDbContext(DbContextOptions<ToDoAppDbContext> options) : base(options)
        {

        }

        //Override the inherited method from the DbContext that is used for configurating the relationshhips, constraints, seeding data...
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //one to many -> Each ToDo has one Status, each status can have many ToDos
            modelBuilder.Entity<ToDo>()
                .HasOne(x => x.Status)
                .WithMany()
                .HasForeignKey(x => x.StatusId);

            //one to many -> Each ToDo has one Category, each category can have many ToDos
            modelBuilder.Entity<ToDo>()
                .HasOne(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.CategoryId);

            //seed data - add inital data in the db
            modelBuilder.Entity<Category>()
                .HasData(
                    new Category { Id = 1, Name = "Work" },
                    new Category { Id = 2, Name = "Home" },
                    new Category { Id = 3, Name = "Exercise" },
                    new Category { Id = 4, Name = "Shopping" },
                    new Category { Id = 5, Name = "Hoby" },
                    new Category { Id = 6, Name = "FreeTime" }
                );

            modelBuilder.Entity<Status>()
                .HasData(
                     new Status { Id = 1, Name = "Open" },
                     new Status { Id = 2, Name = "Closed" }
                 );

            modelBuilder.Entity<ToDo>()
                .HasData(
                new ToDo
                {
                    Id = 1,
                    Description = "Finish project presentation",
                    DueDate = DateTime.Now.AddDays(2),
                    CategoryId = 1, //Work
                    StatusId = 1 //Open
                },
                 new ToDo
                 {
                     Id = 2,
                     Description = "Clean the house",
                     DueDate = DateTime.Now.AddDays(1),
                     CategoryId = 2, //Home
                     StatusId = 1 //Open
                 },
                  new ToDo
                  {
                      Id = 3,
                      Description = "Morning exercise",
                      DueDate = DateTime.Now,
                      CategoryId = 3, //Exercise
                      StatusId = 2 //Closed
                  },
                   new ToDo
                   {
                       Id = 4,
                       Description = "Buy groceries",
                       DueDate = DateTime.Now.AddDays(3),
                       CategoryId = 4, //Shopping
                       StatusId = 1 //Opened
                   },
                   new ToDo
                   {
                       Id = 5,
                       Description = "Watch a movie",
                       DueDate = DateTime.Now,
                       CategoryId = 6, //FreeTime
                       StatusId = 2 //Closed
                   }
                );

            //we want to use the logic for this method that is written in the DbContext parent class, we just want to expand it here
            base.OnModelCreating(modelBuilder);
        }
    }
}
