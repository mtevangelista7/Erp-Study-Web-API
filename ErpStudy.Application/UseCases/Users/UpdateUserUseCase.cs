using ErpStudy.Application.DTOs.Products;
using ErpStudy.Application.DTOs.Users;
using ErpStudy.Application.Interfaces.UsesCases.Products;
using ErpStudy.Application.Interfaces.UsesCases.Users;
using ErpStudy.Application.Validator.ProductDTOValidator;
using ErpStudy.Application.Validator.UserDTOValidator;
using ErpStudy.Domain.Entities;
using ErpStudy.Infrastructure.Data.Interfaces;
using FluentResults;

namespace ErpStudy.Application.UseCases.Users
{
    public class UpdateUserUseCase(IUserRepository userRepository) : IUpdateUserUseCase
    {
        public async Task<Result<User>> ExecuteAsync(UpdateUserDTO request)
        {
            var validationResult = await new UpdateUserDTOValidator().ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                IEnumerable<string> errors = validationResult.Errors.Select(err => err.ErrorMessage);
                return Result.Fail(errors);
            }

            if ((await userRepository.GetById(request.Id)) is null)
            {
                return Result.Fail("Not Found");
            }

            User newUser = new() { Id = request.Id, Email = request.Email, UserName = request.UserName, };

            var user = await userRepository.Update(newUser);

            return Result.Ok(user);
        }
    }
}