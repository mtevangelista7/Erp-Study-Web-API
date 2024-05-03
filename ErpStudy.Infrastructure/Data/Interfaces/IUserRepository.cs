using ErpStudy.Domain.Entities;

namespace ErpStudy.Infrastructure.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> CreateUserAsync(User user);
        Task<bool> UpdateUserAsync(User user);
        Task<User?> GetUserByIdAsync(Guid id);
        Task<List<User>> GetAllUsersAsync();
        Task<bool> DeleteUserAsync(Guid id);
    }
}