namespace ErpStudy.Application.DTOs.Categories
{
    public record CreateCategoryDTO(string Name)
    {
        public string Name { get; set; } = Name;
    }
}