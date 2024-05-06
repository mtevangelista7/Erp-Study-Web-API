using ErpStudy.Domain.Enums;

namespace ErpStudy.Application.DTOs.Products
{
    public record UpdateProductDTO(
        Guid Id,
        string Name,
        string SKUCode,
        double SalesPrice,
        Unity Unity,
        Condition Condition,
        Guid CategoryId);
}