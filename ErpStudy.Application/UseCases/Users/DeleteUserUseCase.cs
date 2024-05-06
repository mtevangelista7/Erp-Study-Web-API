using ErpStudy.Application.DTOs.Users;
using ErpStudy.Application.Interfaces.UsesCases.Users;
using ErpStudy.Application.Validator.UserDTOValidator;
using ErpStudy.Infrastructure.Data.Interfaces;
using FluentResults;

namespace ErpStudy.Application.UseCases.Users
{
    public class DeleteUserUseCase(IUserRepository userRepository) : IDeleteUserUseCase
    {
        public async Task<Result> ExecuteAsync(DeleteUserDTO request)
        {
            var validationResult = await new DeleteUserDTOValidator().ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                IEnumerable<string> errors = validationResult.Errors.Select(err => err.ErrorMessage);
                return Result.Fail(errors);
            }

            await userRepository.Delete(request.Id);
            return Result.Ok();
        }
    }
}