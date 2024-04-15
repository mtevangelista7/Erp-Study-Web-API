using ErpStudyWebAPI.Models;
using System;
using System.Threading.Tasks;

namespace ErpStudyWebAPI.Services.AuthServices
{
    public interface IAuthService
    {
        Task<Guid> RegistraUsuario(Usuario usuario, string senha);
        Task<string> RealizaLogin(string nomeUsuario, string senha);
        Task<bool> UsuarioExiste(string nomeUsuario);
    }
}