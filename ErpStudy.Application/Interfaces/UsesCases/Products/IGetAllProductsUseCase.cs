using ErpStudy.Domain.Entities;
using FluentResults;

namespace ErpStudy.Application.Interfaces.UsesCases.Products
{
    public interface IGetAllProductsUseCase : IUseCaseWithNoParam<List<Product>>
    {
    }
}