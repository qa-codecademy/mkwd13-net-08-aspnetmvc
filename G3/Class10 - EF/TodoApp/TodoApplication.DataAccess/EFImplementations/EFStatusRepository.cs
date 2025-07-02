using TodoApplication.DataAccess.Interfaces;
using TodoApplication.Domain;

namespace TodoApplication.DataAccess.EFImplementations
{
    public class EFStatusRepository : IRepository<Status>
    {
        private readonly TodoAppDbContext _context;

        public EFStatusRepository()
        {
            _context = new TodoAppDbContext();
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
            throw new NotImplementedException();
        }

        public void Update(Status entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
