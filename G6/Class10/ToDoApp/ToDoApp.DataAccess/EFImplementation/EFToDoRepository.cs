using Microsoft.EntityFrameworkCore;
using ToDoApp.DataAccess.Interfaces;
using ToDoApp.Domain;

namespace ToDoApp.DataAccess.EFImplementation
{
    public class EFToDoRepository : IRepository<ToDo>
    {
        //The repo uses the db context to interact with the db using EF
        private readonly ToDoAppDbContext _dbContext;

        public EFToDoRepository(ToDoAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(ToDo entity)
        {
            _dbContext.ToDo.Add(entity); //with this line only, the changes are not applied in the db. It is like just writing the query, but we still have not executed it
            _dbContext.SaveChanges(); //with saveChanges the db is updated with the changes and the new item is added
        }

        public void Delete(int id)
        {
            var todo = GetById(id);
            if(todo != null)
            {
                _dbContext.ToDo.Remove(todo); 
                _dbContext.SaveChanges(); //we need to save the changes (to actually execute the query and update the db)
            }
        }

        public List<ToDo> GetAll()
        {
            //SQL:
            //SELECT * FROM ToDo T
            //var toDos = _dbContext.ToDo
            //    .ToList();

            //SQL:
            //SELECT * FROM ToDo T
            //JOIN Category C ON C.Id = T.CategoryId
            //JOIN Status S ON S.Id = T.StatusId
            var toDos = _dbContext.ToDo
                .Include(x => x.Status) //join
                .Include(x => x.Category) //join -> if we want to access toDo.Category.Name we need to include the category object (to join it) so we can access its properties
                .ToList();

            return toDos;
        }

        public ToDo GetById(int id)
        {
            //SQL:
            //SELECT * FROM ToDo T
            //JOIN Category C ON C.Id = T.CategoryId
            //JOIN Status S ON S.Id = T.StatusId
            //WHERE T.Id = @id

            var todo = _dbContext.ToDo
                .Include(x => x.Status)
                .Include(x => x.Category)
                .FirstOrDefault(x => x.Id == id);
            return todo;
        }

        public void Update(ToDo entity)
        {
           _dbContext.ToDo.Update(entity);
           _dbContext.SaveChanges();
        }
    }
}
