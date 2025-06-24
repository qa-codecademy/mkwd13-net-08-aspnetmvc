using Avenga.TodoApp.DataAccess.Data;
using Avenga.TodoApp.Domain;

namespace Avenga.TodoApp.DataAccess.Repositories
{
    public class TodoRepository : IRepository<Todo>
    {
        //public IEnumerable<Todo> GetAll() => StaticDb.Todos;

        public IEnumerable<Todo> GetAll()
        {
            return StaticDb.Todos;
        }
        public Todo GetById(int id)
        {
            return StaticDb.Todos.SingleOrDefault(x => x.Id == id);
        }
        public void Create(Todo entity)
        {
            entity.Id = StaticDb.Todos.Count + 1;
            StaticDb.Todos.Add(entity);
        }

        public void Update(Todo entity)
        {
            Todo todoFromDb = StaticDb.Todos.SingleOrDefault(x => x.Id == entity.Id);
            int index = StaticDb.Todos.IndexOf(todoFromDb);
            StaticDb.Todos[index] = entity;
        }

        public void Delete(int id)
        {
            Todo todoFromDb = StaticDb.Todos.SingleOrDefault(x => x.Id == id);
            StaticDb.Todos.Remove(todoFromDb);
        }

    }
}
