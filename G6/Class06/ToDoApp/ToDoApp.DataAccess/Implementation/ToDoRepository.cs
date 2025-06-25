using ToDoApp.DataAccess.Interfaces;
using ToDoApp.Domain;

namespace ToDoApp.DataAccess.Implementation
{
    public class ToDoRepository : IRepository<ToDo>
    {
        public void Create(ToDo entity)
        {
            if (entity == null)
            {
                throw new Exception("ToDo item cannot be null");
            }
            //we need to increment the id ourselves
            entity.Id = StaticDb.Todos.Last().Id + 1; //here, we are sure that there is at least one toDo 
            StaticDb.Todos.Add(entity);
        }

        public void Delete(int id)
        {
            //first we need to find the entity that we want to remove and then remove it
            ToDo toDoFromDb = StaticDb.Todos.FirstOrDefault(x => x.Id == id);
            if(toDoFromDb != null) //if we successfully found the entity, remove it
            {
                StaticDb.Todos.Remove(toDoFromDb);
            }
        }

        public List<ToDo> GetAll()
        {
            return StaticDb.Todos; //return all todos from the db
        }

        public ToDo GetById(int id)
        {
            return StaticDb.Todos.FirstOrDefault(x => x.Id == id);
        }

        public void Update(ToDo entity)
        {
            if(entity == null)
            {
                throw new Exception("ToDo item cannot be null");
            }
            ToDo toDoFromDb = GetById(entity.Id);
            int index = StaticDb.Todos.IndexOf(toDoFromDb);
            StaticDb.Todos[index] = entity;
        }
    }
}
