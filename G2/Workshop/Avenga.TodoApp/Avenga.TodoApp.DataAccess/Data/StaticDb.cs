using Avenga.TodoApp.Domain;

namespace Avenga.TodoApp.DataAccess.Data
{
    public static class StaticDb
    {
        public static List<Todo> Todos { get; set; }
        public static List<Category> Categories { get; set; }
        public static List<Status> Statuses { get; set; }

        static StaticDb()
        {
            LoadCategories();
            LoadStatuses();
            LoadTodos();
        }

        private static void LoadCategories()
        {
            Categories = new List<Category>
            {
                new Category { Id = 1, Name = "Work" },
                new Category { Id = 2, Name = "Home" },
                new Category { Id = 3, Name = "Exercise" },
                new Category { Id = 4, Name = "Shopping" },
                new Category { Id = 5, Name = "Hobbie" },
                new Category { Id = 6, Name = "FreeTime" }
            };
        }

        private static void LoadStatuses()
        {
            Statuses = new List<Status>
            {
                new Status { Id = 1, Name = "Open" },
                new Status { Id = 2, Name = "Closed" }
            };
        }

        private static void LoadTodos()
        {
            Todos = new List<Todo>
            {
                new Todo
                {
                    Id = 1,
                    Description = "Finish project presentation",
                    DueDate = DateTime.Today.AddDays(2),
                    CategoryId = 1, // Work
                    StatusId = 1    // Open
                },
                new Todo
                {
                    Id = 2,
                    Description = "Clean the kitchen",
                    DueDate = DateTime.Today.AddDays(-1),
                    CategoryId = 2, // Home
                    StatusId = 1    // Open
                },
                new Todo
                {
                    Id = 3,
                    Description = "Morning jog in the park",
                    DueDate = DateTime.Today,
                    CategoryId = 3, // Exercise
                    StatusId = 2    // Closed
                },
                new Todo
                {
                    Id = 4,
                    Description = "Buy groceries for the week",
                    DueDate = DateTime.Today.AddDays(3),
                    CategoryId = 4, // Shopping
                    StatusId = 1    // Open
                },
                new Todo
                {
                    Id = 5,
                    Description = "Read a chapter from a novel",
                    DueDate = DateTime.Today.AddDays(4),
                    CategoryId = 6, // FreeTime
                    StatusId = 1    // Open
                }
            };
        }
    }

}
