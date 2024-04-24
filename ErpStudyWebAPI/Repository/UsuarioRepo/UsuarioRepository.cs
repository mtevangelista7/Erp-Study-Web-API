using ErpStudyWebAPI.Models;
using ErpStudyWebAPI.Models.DTOs;
using ErpStudyWebAPI.Utilities;
using Microsoft.Data.SqlClient;
using System;
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

            stringBuilder.Append(" INSERT INTO Usuario VALUES ()");

            return Guid.Empty;
        }

        public async Task<Usuario> RetornaUsuario(string nomeUsuario)
        {
            if (string.IsNullOrWhiteSpace(nomeUsuario))
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

        public async Task<bool> AtualizaInfoUsuario(UsuarioCadastroDto usuarioCadastroDto)
        {
            // Abra a conexão
            await using SqlConnection connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            // Monta a consulta update
            const string sQuery = " UPDATE Usuario SET NomeUsuario = @NomeUsuario ";
            await using SqlCommand command = new SqlCommand(sQuery, connection);
            command.Parameters.AddWithValue("@NomeUsuario", usuarioCadastroDto.NomeUsuario);

            // Caso alguma linha tenha sido modificada, retorna true
            return await command.ExecuteNonQueryAsync() > 0;
        }

        public async Task<bool> DeletaUsuario(Guid guidUsuarioId)
        {
            // Abre a conexão
            await using SqlConnection connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            // Monta a query de delete
            const string sQuery = " DELETE FROM Usuario WHERE UsuarioId = @UsuarioId ";
            await using SqlCommand command = new SqlCommand(sQuery, connection);
            command.Parameters.AddWithValue("@UsuarioId", guidUsuarioId);

            // Caso algum item tenha sido alterado, retorna true, caso não false
            return await command.ExecuteNonQueryAsync() > 0;
        }
    }
}