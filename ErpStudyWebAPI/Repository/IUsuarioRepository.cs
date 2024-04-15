using ErpStudyWebAPI.Models;
using System;
using System.Threading.Tasks;

namespace ErpStudyWebAPI.Repository {
    public interface IUsuarioRepository {
        public Task<Guid> InsereUsuario(Usuario usuario);
        public Task<Usuario> RetornaUsuario(string nomeUsuario);
    }
}