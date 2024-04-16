using ErpStudyWebAPI.Models;
using ErpStudyWebAPI.Models.Enums;
using ErpStudyWebAPI.Repository.ProdutoRepo;
using ErpStudyWebAPI.Utilities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ErpStudyWebAPI.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly string _connectionString = Util.StringConexao;

        public async Task InsereProduto(Produto produto)
        {
            StringBuilder stringBuilder = new StringBuilder();

            await using SqlConnection connection = new SqlConnection(_connectionString);

            await connection.OpenAsync();

            stringBuilder.Append(" INSERT INTO Produto ");
            stringBuilder.Append(" ( ");
            stringBuilder.Append(" @Nome, @CodigoSKU, @PrecoVenda, @Unidade, @Condicao, @CategoriaID ");
            stringBuilder.Append(" ) ");

            await using SqlCommand command = new SqlCommand(stringBuilder.ToString(), connection);

            command.Parameters.AddWithValue("@Nome", produto.Nome);
            command.Parameters.AddWithValue("@CodigoSKU", produto.CodigoSKU);
            command.Parameters.AddWithValue("@PrecoVenda", produto.PrecoVenda);
            command.Parameters.AddWithValue("@Unidade", produto.Unidade);
            command.Parameters.AddWithValue("@Condicao", produto.Condicao);
            command.Parameters.AddWithValue("@CategoriaID", produto.Categoria.CategoriaID);

            await command.ExecuteNonQueryAsync();
        }

        public async Task<List<Produto>> RetornaTodosProdutos()
        {
            await using SqlConnection connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            const string sQuery =
                " SELECT * FROM Produto LEFT JOIN Categoria ON Produto.CategoriaID = Caregoria.CategoriaID ";

            await using SqlCommand command = new SqlCommand(sQuery, connection);

            await using SqlDataReader reader = await command.ExecuteReaderAsync();

            List<Produto> produtos = new List<Produto>();

            while (reader.Read())
            {
                Produto produto = new Produto
                {
                    ProdutoID = reader.GetGuid(reader.GetOrdinal("ProdutoID")),
                    Nome = reader.GetString(reader.GetOrdinal("Nome")),
                    CodigoSKU = reader.GetString(reader.GetOrdinal("CodigoSKU")),
                    PrecoVenda = reader.GetDouble(reader.GetOrdinal("PrecoVenda")),
                    Unidade = (Unidade)reader.GetInt32(reader.GetOrdinal("Unidade")),
                    Condicao = (Condicao)reader.GetInt32(reader.GetOrdinal("Condicao")),
                    Categoria = new Categoria
                    {
                        CategoriaID = reader.GetGuid(reader.GetOrdinal("CategoriaID")),
                        Nome = reader.GetString(reader.GetOrdinal("Nome"))
                    }
                };

                produtos.Add(produto);
            }

            await reader.CloseAsync();

            return produtos;
        }

        public async Task<Produto> RetornaProduto(Guid produtoGuid)
        {
            await using SqlConnection connection = new SqlConnection(_connectionString);
            Produto produto;
            await connection.OpenAsync();

            const string sQuery = " SELECT * FROM Produto WHERE Produto.ProdutoID = @ProdutoID ";

            await using SqlCommand command = new SqlCommand(sQuery, connection);

            command.Parameters.AddWithValue("@ProdutoID", produtoGuid);

            produto = (Produto)command.ExecuteScalar();

            return produto;
        }
    }
}