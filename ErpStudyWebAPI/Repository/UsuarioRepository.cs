using ErpStudyWebAPI.Models;
using ErpStudyWebAPI.Models.DTOs;
using Microsoft.Data.SqlClient;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ErpStudyWebAPI.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string _connectionString;

        public UsuarioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public async Task<Guid> InsereUsuario(Usuario usuario)
        {
            StringBuilder stringBuilder = new StringBuilder();

            using SqlConnection connection = new SqlConnection(_connectionString);
            
            connection.Open();

            stringBuilder.Append(" INSERT INTO Usuario  ");

            return Guid.Empty;
        }

        public Task<Usuario> RetornaUsuario(string nomeUsuario)
        {
            throw new NotImplementedException();
        }
    }
}