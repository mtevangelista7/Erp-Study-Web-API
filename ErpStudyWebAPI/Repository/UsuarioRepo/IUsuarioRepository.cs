using ErpStudyWebAPI.Models;
using ErpStudyWebAPI.Models.DTOs;
using System;
using System.Threading.Tasks;

namespace ErpStudyWebAPI.Repository.UsuarioRepo
{
    public interface IUsuarioRepository
    {
        public Task<Guid> InsereUsuario(Usuario usuario);
        public Task<Usuario> RetornaUsuario(string nomeUsuario);
        public Task<bool> AtualizaInfoUsuario(UsuarioCadastroDto usuarioCadastroDto);
        Task<bool> DeletaUsuario(Guid guidUsuarioId);
    }
}