using TodoApplication.DataAccess.Interfaces;
using TodoApplication.Domain;

namespace TodoApplication.DataAccess.Implementations {
	public class StatusRepository : IRepository<Status> {
		public void Add(Status entity) {
			entity.Id = InMemoryDataBase.Statuses.Count + 1;
			InMemoryDataBase.Statuses.Add(entity);
		}

		public void Delete(int id) {
			var status = GetById(id);
			if (status is not null) {
				InMemoryDataBase.Statuses.Remove(status);
			}
		}
		public IEnumerable<Status> GetAll() {
			return InMemoryDataBase.Statuses;
		}

		public Status GetById(int id) {
			return InMemoryDataBase.Statuses.FirstOrDefault(s => s.Id == id);
		}

		public void Update(Status entity) {
			var status = GetById(entity.Id);
			if (status is not null) {
				var statusIndex = InMemoryDataBase.Statuses.IndexOf(status);
				InMemoryDataBase.Statuses[statusIndex] = entity;
			}
		}
	}
}
