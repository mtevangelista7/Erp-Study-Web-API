namespace ErpStudy.Infrastructure.Data.Interfaces
{
    public interface IRepository<T>
    {
        IList<T> GetAll();
        T GetById(Guid id);
        Task Add(T entity);
        Task<T> Update(T entity);
        Task Delete(Guid id);
    }
}