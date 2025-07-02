using TodoApplication.DataAccess.Interfaces;
using TodoApplication.Domain;

namespace TodoApplication.DataAccess.EFImplementations
{
    public class EFCategoryRepository : IRepository<Category>
    {
        private readonly TodoAppDbContext _context;

        public EFCategoryRepository(TodoAppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Category.ToList();
        }

        public Category GetById(int id)
        {
            return _context.Category.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Category entity)
        {
            _context.Category.Update(entity);
            _context.SaveChanges();
        }

        public void Add(Category entity)
        {
            _context.Category.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = GetById(id);
            if (category != null)
            {
                _context.Category.Remove(category);
                _context.SaveChanges();
            }
        }

    }
}
