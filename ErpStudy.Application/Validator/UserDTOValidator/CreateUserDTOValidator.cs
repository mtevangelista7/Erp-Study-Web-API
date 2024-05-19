using ErpStudy.Application.DTOs.Users;
using FluentValidation;

namespace ErpStudy.Application.Validator.UserDTOValidator
{
    public class CreateUserDTOValidator : AbstractValidator<CreateUserDTO>
    {
        public CreateUserDTOValidator()
        {
            RuleFor(user => user.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("A valid email is required.");

            RuleFor(user => user.UserName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Username is required");

            RuleFor(user => user.Password)
                .NotNull()
                .NotEmpty()
                .WithMessage("Password is required");
        }
    }
}