using ToDoApp.Models.Dtos;

namespace ToDoApp.Services.Interfaces
{
    public interface IFilterService
    {
        List<StatusDto> GetStatuses();
        List<CategoryDto> GetCategories();
    }
}
