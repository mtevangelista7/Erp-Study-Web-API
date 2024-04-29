namespace ErpStudy.Application.DTOs.Categories
{
    public record UpdateCategoryDTO(Guid Id, string Name)
    {
        public Guid Id { get; set; } = Id;
        public string Name { get; set; } = Name;
    }
}