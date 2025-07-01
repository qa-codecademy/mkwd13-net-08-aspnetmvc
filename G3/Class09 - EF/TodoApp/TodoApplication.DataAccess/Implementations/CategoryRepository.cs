using System;
using System.Collections.Generic;
using System.Linq;
using TodoApplication.DataAccess.Interfaces;
using TodoApplication.Domain;

namespace TodoApplication.DataAccess.Implementations {
	public class CategoryRepository : IRepository<Category> {
		public void Add(Category entity) {
			entity.Id = InMemoryDataBase.Categories.Count + 1;
			InMemoryDataBase.Categories.Add(entity);
		}

		public void Delete(int id) {
			var category = GetById(id);
			if (category is not null) 
			{
				InMemoryDataBase.Categories.Remove(category);
			}
		}

		public IEnumerable<Category> GetAll() {
			return InMemoryDataBase.Categories;
		}

		public Category GetById(int id) {
			return InMemoryDataBase.Categories.FirstOrDefault(c => c.Id == id);
		}

		public void Update(Category entity) {
			var category = GetById(entity.Id);
			if (category is not null) {
				var categoryIndex = InMemoryDataBase.Categories.IndexOf(category);
				InMemoryDataBase.Categories[categoryIndex] = entity;
			}
		}
	}
}
