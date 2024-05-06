using ErpStudy.Application.DTOs.Users;
using FluentValidation;

namespace ErpStudy.Application.Validator.UserDTOValidator
{
    public class DeleteUserDTOValidator : AbstractValidator<DeleteUserDTO>
    {
        public DeleteUserDTOValidator()
        {
            RuleFor(user => user.Id)
                .NotEmpty();
        }
    }
}