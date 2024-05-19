using ErpStudy.Application.DTOs.Products;
using ErpStudy.Application.DTOs.Users;
using ErpStudy.Application.Interfaces.UsesCases.Users;
using ErpStudy.Application.Validator.ProductDTOValidator;
using ErpStudy.Application.Validator.UserDTOValidator;
using ErpStudy.Domain.Entities;
using ErpStudy.Infrastructure.Data.Interfaces;
using FluentResults;

namespace ErpStudy.Application.UseCases.Users
{
    public class GetUserByIdUseCase(IUserRepository userRepository) : IGetUserByIdUseCase
    {
        public async Task<Result<User>> ExecuteAsync(GetUserByIdDTO request)
        {
            try
            {
                var validationResult = await new GetUserByIdDTOValidator().ValidateAsync(request);

                if (!validationResult.IsValid)
                {
                    IEnumerable<string> errors = validationResult.Errors.Select(err => err.ErrorMessage);
                    return Result.Fail(errors);
                }

                var user = await userRepository.GetById(request.Id);

                return Result.Ok(user);
            }
            catch (Exception ex)
            {
                return Result.Fail([ex.Message]);
            }
        }
    }
}