using ToDoApp.DataAccess.Interfaces;
using ToDoApp.Domain;

namespace ToDoApp.DataAccess.Implementation
{
    public class CategoryRepository : IRepository<Category>
    {
        public void Create(Category entity)
        {
            if (entity == null)
            {
                throw new Exception("Category item cannot be null");
            }
            //we need to increment the id ourselves
            entity.Id = StaticDb.Categories.Last().Id + 1; //here, we are sure that there is at least one category 
            StaticDb.Categories.Add(entity);
        }

        public void Delete(int id)
        {
            //first we need to find the entity that we want to remove and then remove it
            Category category = StaticDb.Categories.FirstOrDefault(x => x.Id == id);
            if (category != null) //if we successfully found the entity, remove it
            {
                StaticDb.Categories.Remove(category);
            }
        }

        public List<Category> GetAll()
        {
            return StaticDb.Categories;
        }

        public Category GetById(int id)
        {
            return StaticDb.Categories.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Category entity)
        {
            if (entity == null)
            {
                throw new Exception("Category item cannot be null");
            }
            Category category = GetById(entity.Id);
            int index = StaticDb.Categories.IndexOf(category);
            StaticDb.Categories[index] = entity;
        }
    }
}
