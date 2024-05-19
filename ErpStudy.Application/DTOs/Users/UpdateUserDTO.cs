namespace ErpStudy.Application.DTOs.Users
{
    public record UpdateUserDTO(
        Guid Id,
        string Email,
        string UserName
    );
}