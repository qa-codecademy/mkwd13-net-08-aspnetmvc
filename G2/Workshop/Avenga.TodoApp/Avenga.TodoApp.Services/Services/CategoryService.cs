using Avenga.TodoApp.DataAccess.Repositories;
using Avenga.TodoApp.Domain;
using Avenga.TodoApp.Services.Services.Interfaces;
using Avenga.TodoApp.ViewModels;

namespace Avenga.TodoApp.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<CategoryVM> GetAllCategories()
        {
            List<CategoryVM> categories = new List<CategoryVM>();
            var categoriesFromDb = _categoryRepository.GetAll();
            foreach (var category in categoriesFromDb)
            {
                categories.Add(new CategoryVM
                {
                    Id = category.Id,
                    Name = category.Name,
                });
            }
            return categories;
        }
    }
}
