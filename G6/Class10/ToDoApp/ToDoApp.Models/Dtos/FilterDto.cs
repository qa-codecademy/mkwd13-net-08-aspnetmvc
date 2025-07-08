namespace ToDoApp.Models.Dtos
{
    public class FilterDto
    {
        //we don't want to send back to the controller a list of domain models, so we create dtos
        public List<CategoryDto> Categories { get; set; }
        public List<StatusDto> Statuses { get; set; }
        public int? CategoryId { get; set; }
        public int? StatusId { get; set; }


    }
}
