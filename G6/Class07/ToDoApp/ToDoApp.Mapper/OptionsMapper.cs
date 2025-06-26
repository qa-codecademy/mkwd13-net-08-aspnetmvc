using ToDoApp.Domain;
using ToDoApp.Models.Dtos;

namespace ToDoApp.Mapper
{
    public static class OptionsMapper
    {
        //we want to map the domain model to a dto
        //it is even more practical to make this an extension method
        public static CategoryDto Map(this Category category)
        {
            return new CategoryDto { Id = category.Id, Name = category.Name };
        }

        public static StatusDto Map(this Status status)
        {
            return new StatusDto { Id = status.Id, Name = status.Name };
        }
    }
}
