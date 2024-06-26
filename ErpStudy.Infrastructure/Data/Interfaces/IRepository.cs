﻿
using ErpStudy.Domain.Entities;

namespace ErpStudy.Infrastructure.Data.Interfaces
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<List<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task Delete(Guid id);
    }
}