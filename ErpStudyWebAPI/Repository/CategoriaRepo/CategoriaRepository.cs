using ErpStudyWebAPI.Models;
using ErpStudyWebAPI.Utilities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ErpStudyWebAPI.Repository.CategoriaRepo
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly string _connectionString = Util.StringConexao;

        public async Task InsereCategoria(Categoria categoria)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string sQuery = " INSERT INTO Categoria (Nome) VALUES (@Nome) ";
            using SqlCommand command = new SqlCommand(sQuery, connection);

            command.Parameters.AddWithValue("@Nome", categoria.Nome);

            await command.ExecuteNonQueryAsync();
        }

        public async Task AtualizaCategoria(Categoria categoria)
        {
            await using SqlConnection connection = new SqlConnection(_connectionString);

            await connection.OpenAsync();

            const string sQuery = " UPDATE Categoria SET Nome = @Nome WHERE CategoriaID = @CategoriaID ";

            await using SqlCommand command = new SqlCommand(sQuery, connection);

            command.Parameters.AddWithValue("@Nome", categoria.Nome);
            command.Parameters.AddWithValue("@CategoriaID", categoria.CategoriaID);

            await command.ExecuteNonQueryAsync();
        }

        public async Task<Categoria> RetornaCategoria(Guid guidId)
        {
            if (guidId == Guid.Empty)
            {
                return null;
            }

            await using SqlConnection connection = new SqlConnection(_connectionString);

            await connection.OpenAsync();

            const string sQuery = " SELECT * FROM Categoria WHERE CategoriaID = @CategoriaID ";

            await using SqlCommand command = new SqlCommand(sQuery, connection);

            command.Parameters.AddWithValue("@CategoriaID", guidId);

            Categoria categoria = (Categoria)await command.ExecuteScalarAsync();

            return categoria;
        }

        public async Task<List<Categoria>> RetornaCategorias()
        {
            await using SqlConnection connection = new SqlConnection(_connectionString);

            await connection.OpenAsync();

            const string sQuery = " SELECT * FROM Categoria ";

            await using SqlCommand command = new SqlCommand(sQuery, connection);

            await using SqlDataReader reader = await command.ExecuteReaderAsync();

            List<Categoria> listcategorias = new List<Categoria>();

            while (await reader.ReadAsync())
            {
                Categoria categoria = new Categoria
                {
                    CategoriaID = reader.GetGuid("CategoriaID"), Nome = reader.GetString(reader.GetOrdinal("Nome"))
                };

                listcategorias.Add(categoria);
            }

            return listcategorias;
        }

        public async Task<Guid> DeletaCategoria(Guid guidId)
        {
            if (guidId == Guid.Empty)
            {
                return Guid.Empty;
            }

            await using SqlConnection connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            const string sQuery = " DELETE FROM Categoria WHERE CategoriaID = @CategoriaID";
            await using SqlCommand command = new SqlCommand(sQuery, connection);
            command.Parameters.AddWithValue("@CategoriaID", guidId);

            // Caso algum dado tenha sido deletado, retorna o id da categoria selecionada
            // Se não, retorna o Guid vazio indicando que a categoria não foi selecionada
            return await command.ExecuteNonQueryAsync() > 0 ? guidId : Guid.Empty;
        }
    }
}