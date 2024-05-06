using ErpStudy.Domain.Entities;

namespace ErpStudy.Application.Interfaces.UsesCases.Users
{
    public interface IGetAllUsersUseCase : IUseCaseWithNoParam<List<User>>
    {
    }
}