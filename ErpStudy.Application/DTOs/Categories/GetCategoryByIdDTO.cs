namespace ErpStudy.Application.DTOs.Categories
{
    public record GetCategoryByIdDTO(Guid Id)
    {
        public Guid Id { get; set; } = Id;
    }
}