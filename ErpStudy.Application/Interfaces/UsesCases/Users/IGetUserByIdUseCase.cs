using ErpStudy.Application.DTOs.Users;
using ErpStudy.Domain.Entities;

namespace ErpStudy.Application.Interfaces.UsesCases.Users
{
    public interface IGetUserByIdUseCase : IUseCase<GetUserByIdDTO, User>
    {
    }
}