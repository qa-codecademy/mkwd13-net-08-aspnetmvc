using Avenga.TodoApp.Domain;

namespace Avenga.TodoApp.DataAccess.Repositories
{
    public class TodoEfRepository : IRepository<Todo>
    {
        private readonly TodoDbContext _db;
        public TodoEfRepository(TodoDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Todo> GetAll()
        {
            return _db.Todos;
        }
        public Todo GetById(int id)
        {
            return _db.Todos.SingleOrDefault(x => x.Id == id);
        }
        public void Create(Todo entity)
        {
            _db.Todos.Add(entity);
            _db.SaveChanges();
        }
        public void Update(Todo entity)
        {
            _db.Todos.Update(entity);
            _db.SaveChanges();
        }
        public void Delete(int id)
        {
            var todo = _db.Todos.SingleOrDefault(x => x.Id == id);
            if (todo != null)
                _db.Todos.Remove(todo);
            _db.SaveChanges();
        }
    }
}
