using ErpStudyWebAPI.Models;
using ErpStudyWebAPI.Utilities;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace ErpStudyWebAPI.Repository.UsuarioRepo
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string _connectionString = Util.StringConexao;
        
        public async Task<Guid> InsereUsuario(Usuario usuario)
        {
            StringBuilder stringBuilder = new StringBuilder();

            await using SqlConnection connection = new SqlConnection(_connectionString);
            
            await connection.OpenAsync();

            stringBuilder.Append(" INSERT INTO Usuario (NomeUsuario, PasswordHash, PasswordSalt) VALUES ");
            stringBuilder.Append(" (@NomeUsuario, @PasswordHash, @PasswordSalt) ");

            await using SqlCommand command = new SqlCommand(stringBuilder.ToString(), connection);
            command.Parameters.AddWithValue("@NomeUsuario", usuario.NomeUsuario);
            command.Parameters.AddWithValue("@PasswordHash", usuario.PasswordHash);
            command.Parameters.AddWithValue("@PasswordSalt", usuario.PasswordSalt);

            if (await command.ExecuteNonQueryAsync() > 0)
            {
                //return usuario.UsuarioId;
            }

            return Guid.Empty;
        }

        public async Task<Usuario> RetornaUsuario(string nomeUsuario)
        {
            Usuario usuario = null;

            if (String.IsNullOrWhiteSpace(nomeUsuario))
            {
                return null;
            }
            
            await using SqlConnection connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            
            const string sQuery = " SELECT * FROM Usuario WHERE NomeUsuario = @NomeUsuario ";
            await using SqlCommand command = new SqlCommand(sQuery, connection);           
            command.Parameters.AddWithValue("@NomeUsuario", nomeUsuario);
            await using SqlDataReader reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                usuario = new Usuario
                {
                    UsuarioId = reader.GetGuid("UsuarioId"),
                    NomeUsuario = reader.GetString(reader.GetOrdinal("NomeUsuario")),
                    PasswordHash = (byte[])reader["PasswordHash"],
                    PasswordSalt = (byte[])reader["PasswordSalt"]
                };
            }

            return usuario;
        }
    }
}