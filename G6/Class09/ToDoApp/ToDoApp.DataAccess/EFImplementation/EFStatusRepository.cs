using ToDoApp.DataAccess.Interfaces;
using ToDoApp.Domain;

namespace ToDoApp.DataAccess.EFImplementation
{
    public class EFStatusRepository : IRepository<Status>
    {
        private readonly ToDoAppDbContext _dbContext;

        public EFStatusRepository(ToDoAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Status entity)
        {
            _dbContext.Status.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var status = GetById(id);
            if(status != null)
            {
                _dbContext.Status.Remove(status);
                _dbContext.SaveChanges();
            }
        }

        public List<Status> GetAll()
        {
            return _dbContext.Status.ToList();  
        }

        public Status GetById(int id)
        {
            return _dbContext.Status.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Status entity)
        {
            _dbContext.Status.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
