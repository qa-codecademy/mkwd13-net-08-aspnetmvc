using Avenga.TodoApp.DataAccess.Data;
using Avenga.TodoApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace Avenga.TodoApp.DataAccess
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions options) : base(options) { }


        public DbSet<Todo> Todos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Todo>()
                .HasData(StaticDb.Todos);

            modelBuilder.Entity<Category>()
                .HasData(StaticDb.Categories);

            modelBuilder.Entity<Status>()
                .HasData(StaticDb.Statuses);

        }
    }
}
