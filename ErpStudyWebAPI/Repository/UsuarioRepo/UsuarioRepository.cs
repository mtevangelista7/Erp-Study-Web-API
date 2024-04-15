using ErpStudyWebAPI.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ErpStudyWebAPI.Repository.UsuarioRepo
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

            await using SqlConnection connection = new SqlConnection(_connectionString);
            
            await connection.OpenAsync();

            stringBuilder.Append(" INSERT INTO Usuario VALUES ()");

            return Guid.Empty;
        }

        public async Task<Usuario> RetornaUsuario(string nomeUsuario)
        {
            if (String.IsNullOrWhiteSpace(nomeUsuario))
            {
                return null;
            }
            
            await using SqlConnection connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            
            const string sQuery = " SELECT * FROM Usuario WHERE NomeUsuario = @NomeUsuario ";
            await using SqlCommand command = new SqlCommand(sQuery, connection);
            
            command.Parameters.AddWithValue("@NomeUsuario", nomeUsuario);
            Usuario usuario = (Usuario)await command.ExecuteScalarAsync();
            
            return usuario;
        }
    }
}