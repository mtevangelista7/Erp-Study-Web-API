using ErpStudy.Application.DTOs.Users;
using FluentValidation;

namespace ErpStudy.Application.Validator.UserDTOValidator
{
    public class UpdateUserDTOValidator : AbstractValidator<UpdateUserDTO>
    {
        public UpdateUserDTOValidator()
        {
            RuleFor(user => user.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Email is required");

            RuleFor(user => user.Email)
                .EmailAddress()
                .WithMessage("Valid email is required");

            RuleFor(user => user.UserName)
                .NotNull()
                .NotEmpty()
                .WithMessage("User name is required");
        }
    }
}