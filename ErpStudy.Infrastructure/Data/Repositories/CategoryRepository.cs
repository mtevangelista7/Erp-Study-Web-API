using ErpStudy.Domain.Entities;
using ErpStudy.Infrastructure.Data.Context;
using ErpStudy.Infrastructure.Data.Interfaces;

namespace ErpStudy.Infrastructure.Data.Repositories
{
    public class CategoryRepository(AplicationDbContext context) : EFRepository<Category>(context), ICategoryRepository;
}