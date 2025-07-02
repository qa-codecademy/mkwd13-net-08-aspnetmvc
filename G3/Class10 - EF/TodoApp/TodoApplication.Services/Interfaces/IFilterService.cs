using TodoApplication.Dtos.Dto;

namespace TodoApplication.Services.Interfaces
{
    public interface IFilterService
    {
        List<CategoryDto> GetCategories();
        List<StatusDto> GetStatuses();
    }
}
