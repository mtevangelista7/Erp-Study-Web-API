using ErpStudy.Application.DTOs.Users;
using FluentValidation;

namespace ErpStudy.Application.Validator.UserDTOValidator
{
    public class GetUserByIdDTOValidator : AbstractValidator<GetUserByIdDTO>
    {
        public GetUserByIdDTOValidator()
        {
            RuleFor(user => user.Id)
                .NotEmpty();
        }
    }
}