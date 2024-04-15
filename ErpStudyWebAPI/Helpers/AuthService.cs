using ErpStudyWebAPI.Models;
using ErpStudyWebAPI.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ErpStudyWebAPI.Helpers
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IUsuarioRepository _usuarioRepository;

        public AuthService(IUsuarioRepository usuarioRepository, IConfiguration configuration)
        {
            _configuration = configuration;
            _usuarioRepository = usuarioRepository;
        }

        private string CriaToken(Usuario usuario)
        {
            List<Claim> claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, usuario.UsuarioId.ToString()), new Claim(ClaimTypes.Name, usuario.NomeUsuario) };
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public async Task<string> RealizaLogin(string nomeUsuario, string senha)
        {
            string tokenUsuarioLogado;

            Usuario usuario = await _usuarioRepository.RetornaUsuario(nomeUsuario.ToLower());

            if (usuario == null)
            {
                // usuario não localizado
                return null;
            }
            else if (!VerificaSenhaHash(senha, usuario.PasswordHash, usuario.PasswordSalt))
            {
                // senha incorreta
                return null;
            }
            else
            {
                tokenUsuarioLogado = CriaToken(usuario);
            }

            return tokenUsuarioLogado;
        }

        public async Task<Guid> RegistraUsuario(Usuario usuario, string senha)
        {
            if (await UsuarioExiste(usuario.NomeUsuario)) {
                return Guid.Empty;
            }

            CriaHashSenha(senha, out byte[] passwordHash, out byte[] passwordSalt);

            usuario.PasswordHash = passwordHash;
            usuario.PasswordSalt = passwordSalt;

            return await _usuarioRepository.InsereUsuario(usuario);
        }

        private void CriaHashSenha(string senha, out byte[] hashSenha, out byte[] senhaSalt)
        {
            using HMACSHA512 hmac = new System.Security.Cryptography.HMACSHA512();
            senhaSalt = hmac.Key;
            hashSenha = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
        }

        public async Task<bool> UsuarioExiste(string nomeUsuario)
        {
            return await _usuarioRepository.RetornaUsuario(nomeUsuario) != null;
        }

        private bool VerificaSenhaHash(string senha, IReadOnlyList<byte> senhaHash, byte[] senhaSalt)
        {
            using HMACSHA512 hmac = new System.Security.Cryptography.HMACSHA512(senhaSalt);
            byte[] computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
            return !computedHash.Where((t, i) => t != senhaHash[i]).Any();
        }
    }
}