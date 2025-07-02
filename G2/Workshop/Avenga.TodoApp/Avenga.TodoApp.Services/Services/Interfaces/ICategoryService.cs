using Avenga.TodoApp.ViewModels;

namespace Avenga.TodoApp.Services.Services.Interfaces
{
    public interface ICategoryService
    {
        List<CategoryVM> GetAllCategories();
    }
}
