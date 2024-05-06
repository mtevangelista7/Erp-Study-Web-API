using ErpStudy.Domain.Enums;

namespace ErpStudy.Application.DTOs.Products
{
    public record CreateProductDTO(
        string Name,
        string SKUCode,
        double SalesPrice,
        Unity Unity,
        Condition Condition,
        Guid CategoryId);
}