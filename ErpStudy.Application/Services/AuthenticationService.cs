using ErpStudy.Application.Interfaces.Services;
using ErpStudy.Domain.Entities;
using ErpStudy.Domain.ValueObjects;
using ErpStudy.Infrastructure.Data.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ErpStudy.Application.Services
{
    public class AuthenticationService(
        IUserRepository userRepository,
        IMemoryCache memoryCache,
        IConfiguration configuration)
        : IAuthenticationService
    {
        public async Task<string> GenerateAccessToken(string emailAddress, string password)
        {
            User? user = await userRepository.GetByEmail(emailAddress);

            if (user is null)
            {
                return string.Empty;
            }

            if (!CheckPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return string.Empty;
            }

            string tokenUserLoggedIn = RetrievesCacheToken(user.Id);

            if (!string.IsNullOrWhiteSpace(tokenUserLoggedIn))
            {
                return tokenUserLoggedIn;
            }

            tokenUserLoggedIn = CreateToken(user);

            StoresJwtCache(user.Id, tokenUserLoggedIn);

            return tokenUserLoggedIn;
        }

        public bool CheckPasswordHash(string password, IReadOnlyList<byte> passwordHash, byte[] passwordSalt)
        {
            using HMACSHA512 hmac = new(passwordSalt);
            byte[] computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return !computedHash.Where((t, i) => t != passwordHash[i]).Any();
        }

        public string RetrievesCacheToken(Guid id)
        {
            return memoryCache.TryGetValue(id.ToString(), out string cachedToken) ? cachedToken : null;
        }

        public string CreateToken(User user)
        {
            // Aqui definimos nossas claims (propriedades do token)
            List<Claim> claims =
            [
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            ];

            // Recupera a chave do appsetting, realiza o enconding e converte em bytes
            SymmetricSecurityKey keySecretEncrypted = new(Encoding.ASCII
                .GetBytes(configuration.GetSection("AppSettings:Token").Value));

            // Aqui criamos nossa credencial de assinatura, usando a chave recupera acima
            // para assinar os tokens JWT
            SigningCredentials creds =
                new SigningCredentials(keySecretEncrypted, SecurityAlgorithms.HmacSha512Signature);

            // Aqui definimos as propriedades para nosso token
            SecurityTokenDescriptor tokenPropriedades = new SecurityTokenDescriptor
            {
                // Para nosso sujeito passamos as claims que criamos acima
                Subject = new ClaimsIdentity(claims),
                // Definimos que o token expira um dia após sua criação
                Expires = DateTime.Now.AddDays(1),
                // Passamos nossa chave de criptografia
                SigningCredentials = creds
            };

            // variável que gera o token
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            // realiza a criação do troken
            SecurityToken token = tokenHandler.CreateToken(tokenPropriedades);

            // Retorna o token compactado
            return tokenHandler.WriteToken(token);
        }

        public void StoresJwtCache(Guid id, string token)
        {
            memoryCache.Set(id.ToString(), token, TimeSpan.FromDays(1));
        }
    }
}