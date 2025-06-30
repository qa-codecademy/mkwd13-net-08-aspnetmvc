using Microsoft.EntityFrameworkCore;
using TodoApplication.Domain;

namespace TodoApplication.DataAccess
{
    /// <summary>
    ///     Defines and configures the database context for our entities, representing the interaction (session) with the database
    /// </summary>
    public class TodoAppDbContext : DbContext
    {
        // =====> Defining database tables
        // DbSet<T> => represents a collection of entities of type T that can be queried and saved
        // It corresponds to a table in the database where the properties in the entities represent the table columns
        public DbSet<Todo> Todo { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Category> Category { get; set; }

        public TodoAppDbContext(DbContextOptions<TodoAppDbContext> options) : base(options)
        {

        }

        // =====> Override the inherited method from the DbContext class used to configure relationships, constraints, seed data etc...
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // =====> Configure relationships and properties using Fluent API
            // The Fluent API is a way to configure your entity models in EF Core by using method chaining, providing an alternative to Data Annotations

            modelBuilder.Entity<Todo>()
                .HasOne(todo => todo.Status)
                .WithMany()
                .HasForeignKey(todo => todo.StatusId);
            // One To Many Relation => Each Todo has one Status, each Status can have many Todos

            modelBuilder.Entity<Todo>()
                .HasOne(todo => todo.Category)
                .WithMany()
                .HasForeignKey(todo => todo.CategoryId);
            // One To Many Relation => Each Todo has one Category, each Category can have many Todos


            // =====> More configurations ...


            base.OnModelCreating(modelBuilder);
        }
    }
}
