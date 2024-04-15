using ErpStudyWebAPI.Models;
using System;
using System.Threading.Tasks;

namespace ErpStudyWebAPI.Repository.UsuarioRepo
{
    public interface IUsuarioRepository
    {
        public Task<Guid> InsereUsuario(Usuario usuario);
        public Task<Usuario> RetornaUsuario(string nomeUsuario);
    }
}