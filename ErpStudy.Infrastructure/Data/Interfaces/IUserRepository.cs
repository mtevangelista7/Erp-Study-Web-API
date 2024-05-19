using ErpStudy.Domain.Entities;
using ErpStudy.Domain.ValueObjects;

namespace ErpStudy.Infrastructure.Data.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<User> GetByUserName(string userName);
        public Task<User> GetByEmail(string email);
    }
}