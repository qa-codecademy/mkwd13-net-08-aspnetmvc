using Microsoft.EntityFrameworkCore;
using TodoApplication.DataAccess.Interfaces;
using TodoApplication.Domain;

namespace TodoApplication.DataAccess.EFImplementations
{
    public class EFTodoRepository : ITodoRepository
    {
        private readonly TodoAppDbContext _context;

        public EFTodoRepository()
        {
            _context = new TodoAppDbContext();
        }

        public IEnumerable<Todo> GetAll()
        {
            var allTodos = _context.Todo
                .Include(todo => todo.Category)
                .Include(todo => todo.Status)
                .ToList();

            // ===> SQL translation: 
            // SELECT * FROM Todo t
            // JOIN Category c ON c.Id = t.CategoryId
            // JOIN Status s ON s.Id = t.StatusId

            return allTodos;
        }

        public Todo GetById(int id)
        {
            return _context.Todo
                .Include(todo => todo.Category)
                .Include(todo => todo.Status)
                .FirstOrDefault(todo => todo.Id == id);
        }

        public IEnumerable<Todo> GetCompletedTodos()
        {
            return _context.Todo
                .Include(t => t.Category)
                .Include(t => t.Status)
                .Where(t => t.Status.Name == "Completed")
                .ToList();
        }

        public void Update(Todo entity)
        {
            _context.Todo.Update(entity);
            _context.SaveChanges();
        }

        public void Add(Todo entity)
        {
            _context.Todo.Add(entity);
            _context.SaveChanges();
            // ===> SQL translation: 
            // INSERT INTO Todo (* columns names *)
            // VALUES (* values from entity *)
        }

        public void Delete(int id)
        {
            var todo = GetById(id);
            if (todo is not null)
            {
                _context.Todo.Remove(todo);
                _context.SaveChanges();
            }
        }

    }
}
