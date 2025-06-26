using ToDoApp.Domain;

namespace ToDoApp.DataAccess.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        //CRUD methods for accessing the db
        List<T> GetAll();
        T GetById (int id); 
        void Create(T entity);
        void Update(T entity);  
        void Delete(int id);
    }
}
