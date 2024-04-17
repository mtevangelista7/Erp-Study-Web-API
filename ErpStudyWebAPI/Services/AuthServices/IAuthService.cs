using ErpStudyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ErpStudyWebAPI.Services.AuthServices
{
    public interface IAuthService
    {
        Task<string> RegistraUsuario(Usuario usuario, string senha);
        Task<string> RealizaLogin(string nomeUsuario, string senha);
        Task<bool> UsuarioExiste(string nomeUsuario);
        string CriaToken(Usuario usuario);
        void CriaHashSenha(string senha, out byte[] hashSenha, out byte[] senhaSalt);
        bool VerificaSenhaHash(string senha, IReadOnlyList<byte> senhaHash, byte[] senhaSalt);
        void ArmazenaTokenJWTCache(Guid guidUsuario, string token);
        string RecuperaTokenJWTCache(Guid guidUsuario);
    }
}