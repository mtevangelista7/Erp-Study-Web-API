using ErpStudyWebAPI.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace ErpStudyWebAPI.Repository
{
    public class CategoriaRepository
    {
        private readonly string _connectionString;

        public CategoriaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

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
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string sQuery = " UPDATE Categoria SET Nome = @Nome WHERE CategoriaID = @CategoriaID ";
            using SqlCommand command = new SqlCommand(sQuery, connection);

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

            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string sQuery = " SELECT * FROM Categoria WHERE CategoriaID = @CategoriaID ";
            using SqlCommand command = new SqlCommand(sQuery, connection);

            command.Parameters.AddWithValue("@CategoriaID", guidId);

            Categoria categoria = (Categoria)await command.ExecuteScalarAsync();
            return categoria;
        }

        public async Task<List<Categoria>> RetornaCategorias()
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string sQuery = " SELECT * FROM Categoria ";
            using SqlCommand command = new SqlCommand(sQuery, connection);

            using SqlDataReader reader = await command.ExecuteReaderAsync();

            List<Categoria> listcategorias = new List<Categoria>();

            while (reader.Read())
            {
                Categoria categoria1 = new Categoria
                {
                    CategoriaID = reader.GetGuid("CategoriaID"),
                    Nome = reader.GetString(reader.GetOrdinal("Nome"))
                };

                listcategorias.Add(categoria1);
            }

            return listcategorias;
        }

        public async Task DeletaCategoria(Guid guidId)
        {
            if (guidId == Guid.Empty)
            {
                return;
            }

            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string sQuery = " DELETE FROM Categoria WHERE CategoriaID = @CategoriaID";
            using SqlCommand command = new SqlCommand(sQuery, connection);

            command.Parameters.AddWithValue("@CategoriaID", guidId);

            await command.ExecuteNonQueryAsync();
        }
    }
}
