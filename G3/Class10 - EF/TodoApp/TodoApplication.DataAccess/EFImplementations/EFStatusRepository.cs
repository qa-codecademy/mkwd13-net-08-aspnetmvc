using TodoApplication.DataAccess.Interfaces;
using TodoApplication.Domain;

namespace TodoApplication.DataAccess.EFImplementations
{
    public class EFStatusRepository : IRepository<Status>
    {
        private readonly TodoAppDbContext _context;

        public EFStatusRepository(TodoAppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Status> GetAll()
        {
            return _context.Status.ToList();
        }

        public Status GetById(int id)
        {
            return _context.Status.FirstOrDefault(s => s.Id == id);
        }

        public void Add(Status entity)
        {
            _context.Status.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Status entity)
        {
            _context.Status.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var status = GetById(id);
            if (status != null)
            {
                _context.Status.Remove(status);
                _context.SaveChanges();
            }
        }

    }
}
