namespace ErpStudy.Application.DTOs.Categories
{
    public record DeleteCategoryDTO(Guid Id)
    {
        public Guid Id { get; set; } = Id;
    }
}