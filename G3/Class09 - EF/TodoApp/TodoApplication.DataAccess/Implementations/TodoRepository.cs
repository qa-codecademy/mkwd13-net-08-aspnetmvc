using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApplication.DataAccess.Interfaces;
using TodoApplication.Domain;

namespace TodoApplication.DataAccess.Implementations {
	public class TodoRepository : ITodoRepository {
		public void Add(Todo entity) {
			entity.Id = InMemoryDataBase.Todos.Count + 1;
			InMemoryDataBase.Todos.Add(entity);
		}

		public void Delete(int id) {
			var todo = GetById(id);
			if (todo is not null) 
			{
				InMemoryDataBase.Todos.Remove(todo);
			}
		}

		public IEnumerable<Todo> GetAll() {
			return InMemoryDataBase.Todos;
		}

		public Todo GetById(int id) {
			return InMemoryDataBase.Todos.FirstOrDefault(t => t.Id == id);
		}

		public IEnumerable<Todo> GetCompletedTodos() {
			return InMemoryDataBase.Todos.Where(t => t.StatusId == 2).ToList();
		}

		public void Update(Todo entity) {
			var todo = GetById(entity.Id);
			if(todo is not null) 
			{
				var todoIndex = InMemoryDataBase.Todos.IndexOf(todo);
				InMemoryDataBase.Todos[todoIndex] = entity;
			}
		}
	}
}
