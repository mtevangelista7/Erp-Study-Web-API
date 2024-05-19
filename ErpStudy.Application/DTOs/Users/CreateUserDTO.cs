using ErpStudy.Domain.ValueObjects;

namespace ErpStudy.Application.DTOs.Users
{
    public record CreateUserDTO(string Email, string UserName, string Password);
}