using ErpStudy.Application.Interfaces.UsesCases.Users;
using ErpStudy.Domain.Entities;
using ErpStudy.Infrastructure.Data.Interfaces;
using FluentResults;

namespace ErpStudy.Application.UseCases.Users
{
    public class GetAllUsersUseCase(IUserRepository userRepository) : IGetAllUsersUseCase
    {
        public async Task<Result<List<User>>> ExecuteAsync()
        {
            try
            {
                return Result.Ok(await userRepository.GetAll());
            }
            catch (Exception ex)
            {
                return Result.Fail([ex.Message]);
            }
        }
    }
}