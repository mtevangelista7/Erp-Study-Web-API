using ErpStudy.Domain.Entities;

namespace ErpStudy.Infrastructure.Data.Interfaces
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<IList<T>> GetAll();
        Task<T> GetById(Guid id);
        Task Add(T entity);
        Task<T> Update(T entity);
        Task Delete(Guid id);
    }
}