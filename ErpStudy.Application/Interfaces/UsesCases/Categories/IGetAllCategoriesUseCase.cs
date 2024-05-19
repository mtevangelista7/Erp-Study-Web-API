using ErpStudy.Application.DTOs.Categories;
using ErpStudy.Domain.Entities;

namespace ErpStudy.Application.Interfaces.UsesCases.Categories
{
    public interface IGetAllCategoriesUseCase : IUseCaseWithNoParam<List<Category>>
    {
    }
}