using ErpStudy.Domain.Entities;
using ErpStudy.Domain.ValueObjects;
using ErpStudy.Infrastructure.Data.Context;
using ErpStudy.Infrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ErpStudy.Infrastructure.Data.Repositories
{
    public class UserRepository(AplicationDbContext context) : EFRepository<User>(context), IUserRepository
    {
        public async Task<User> GetByUserName(string userName)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.UserName == userName) ??
                   throw new Exception("Entity not found");
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Email == email) ?? null;
        }
    }
}