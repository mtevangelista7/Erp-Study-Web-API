using ErpStudy.Domain.Entities;
using ErpStudy.Infrastructure.Data.Context;
using ErpStudy.Infrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ErpStudy.Infrastructure.Data.Repositories
{
    public class EFRepository<T> : IRepository<T> where T : EntityBase
    {
        protected AplicationDbContext _context;
        protected DbSet<T> _dbSet;

        public EFRepository(AplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IList<T>> GetAll()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> Update(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(Guid id)
        {
            _dbSet.Remove(await GetById(id));
            await _context.SaveChangesAsync();
        }
    }
}