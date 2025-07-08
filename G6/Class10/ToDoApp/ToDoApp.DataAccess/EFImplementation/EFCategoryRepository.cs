using ToDoApp.DataAccess.Interfaces;
using ToDoApp.Domain;

namespace ToDoApp.DataAccess.EFImplementation
{
    public class EFCategoryRepository : IRepository<Category>
    {
        private readonly ToDoAppDbContext _dbContext;

        public EFCategoryRepository(ToDoAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Category entity)
        {
            _dbContext.Category.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = GetById(id);
            if(category != null)
            {
                _dbContext.Category.Remove(category);
                _dbContext.SaveChanges();
            }
        }

        public List<Category> GetAll()
        {
            return _dbContext.Category.ToList();
        }

        public Category GetById(int id)
        {
            return _dbContext.Category.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Category entity)
        {
            _dbContext.Category.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
