using ErpStudy.Application.DTOs.Users;
using ErpStudy.Application.Interfaces.Services;
using ErpStudy.Application.Interfaces.UsesCases.Users;
using ErpStudy.Application.Validator.UserDTOValidator;
using ErpStudy.Domain.Entities;
using ErpStudy.Infrastructure.Data.Interfaces;
using FluentResults;
using System.Security.Cryptography;

namespace ErpStudy.Application.UseCases.Users
{
    public class CreateUserUseCase(IUserRepository userRepository, IAuthenticationService authenticationService)
        : ICreateUserUseCase
    {
        public async Task<Result<string>> ExecuteAsync(CreateUserDTO request)
        {
            try
            {
                var validationResult = await new CreateUserDTOValidator().ValidateAsync(request);

                if (!validationResult.IsValid)
                {
                    IEnumerable<string> errors = validationResult.Errors.Select(err => err.ErrorMessage);
                    return Result.Fail(errors);
                }

                User user = new() { Email = request.Email, UserName = request.UserName };
                
                var tokenAccess = await UserRegister(user, request.Password);

                return tokenAccess is null ? Result.Fail("") : Result.Ok(tokenAccess);
            }
            catch (Exception ex)
            {
                return Result.Fail([ex.Message]);
            }
        }

        private async Task<string> UserRegister(User user, string password)
        {
            if (await UserExisted(user.Email))
            {
                return string.Empty;
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await userRepository.Add(user);
            
            string tokenUsuarioCadastrado = await authenticationService.GenerateAccessToken(user.Email, password);
                
            authenticationService.StoresJwtCache(user.Id, tokenUsuarioCadastrado);

            return tokenUsuarioCadastrado;
        }

        private async Task<bool> UserExisted(string email)
        {
            return await userRepository.GetByEmail(email) != null!;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using HMACSHA512 hmac = new();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}