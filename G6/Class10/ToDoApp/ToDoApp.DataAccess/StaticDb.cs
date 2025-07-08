using ToDoApp.Domain;

namespace ToDoApp.DataAccess
{
    public static class StaticDb
    {
        public static List<ToDo> Todos { get; set; }
        public static List<Category> Categories { get; set; }
        public static List<Status> Statuses { get; set; }

        static StaticDb()
        {
            LoadCategories();
            LoadStatuses();
            LoadToDos();
        }
        public static void LoadCategories()
        {
            Categories = new List<Category>()
            {
                new Category { Id = 1, Name = "Work"},
                new Category { Id = 2, Name = "Home"},
                new Category { Id = 3, Name = "Exercise"},
                new Category { Id = 4, Name = "Shopping"},
                new Category { Id = 5, Name = "Hoby"},
                new Category { Id = 6, Name = "FreeTime"},
            };
        }

        public static void LoadStatuses()
        {
            Statuses = new List<Status>()
            {
                new Status { Id = 1, Name = "Open"},
                new Status { Id = 2, Name = "Closed"}
            };
        }

        public static void LoadToDos()
        {
            Todos = new List<ToDo>
            {
                new ToDo {
                    Id = 1, 
                    Description = "Finish project presentation",
                    DueDate = DateTime.Now.AddDays(2),
                    CategoryId = 1, //Work
                    StatusId = 1 //Open
                  },
                 new ToDo {
                    Id = 2,
                    Description = "Clean the house",
                    DueDate = DateTime.Now.AddDays(1),
                    CategoryId = 2, //Home
                    StatusId = 1 //Open
                  },
                  new ToDo {
                    Id = 3,
                    Description = "Morning exercise",
                    DueDate = DateTime.Now,
                    CategoryId = 3, //Exercise
                    StatusId = 2 //Closed
                  },
                   new ToDo {
                    Id = 4,
                    Description = "Buy groceries",
                    DueDate = DateTime.Now.AddDays(3),
                    CategoryId = 4, //Shopping
                    StatusId = 1 //Opened
                  },
                   new ToDo {
                    Id = 5,
                    Description = "Watch a movie",
                    DueDate = DateTime.Now,
                    CategoryId = 6, //FreeTime
                    StatusId = 2 //Closed
                  },
            };
        }
    }
}
