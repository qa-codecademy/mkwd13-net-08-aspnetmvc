using Avenga.TodoApp.Domain;

namespace Avenga.TodoApp.DataAccess.Repositories
{
    public class CategoryEfRepository : IRepository<Category>
    {
        private readonly TodoDbContext _db;
        public CategoryEfRepository(TodoDbContext db)
        {   
            _db = db;
        }

        public IEnumerable<Category> GetAll()
        {
            return _db.Categories;
        }
        public Category GetById(int id)
        {
            return _db.Categories.SingleOrDefault(x => x.Id == id);
        }
        public void Create(Category entity)
        {
            _db.Categories.Add(entity);
            _db.SaveChanges();
        }
        public void Update(Category entity)
        {
            _db.Categories.Update(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = _db.Categories.SingleOrDefault(x => x.Id == id);
            if (category != null) 
                _db.Categories.Remove(category);
            _db.SaveChanges();
        }
    }
}
