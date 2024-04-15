using ErpStudyWebAPI.Models;
using ErpStudyWebAPI.Models.Enums;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErpStudyWebAPI.Repository
{
    public class ProdutoRepository
    {
        private readonly string _connectionString;

        public ProdutoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void InsereProduto(Produto produto)
        {
            StringBuilder stringBuilder = new StringBuilder();

            using SqlConnection connection = new SqlConnection(_connectionString);
            
            connection.Open();

            stringBuilder.Append(" INSERT INTO Produto ");
            stringBuilder.Append(" ( ");
            stringBuilder.Append(" @Nome, @CodigoSKU, @PrecoVenda, @Unidade, @Condicao, @CategoriaID ");
            stringBuilder.Append(" ) ");

            using (SqlCommand command = new SqlCommand(stringBuilder.ToString(), connection))
            {
                command.Parameters.AddWithValue("@Nome", produto.Nome);
                command.Parameters.AddWithValue("@CodigoSKU", produto.CodigoSKU);
                command.Parameters.AddWithValue("@PrecoVenda", produto.PrecoVenda);
                command.Parameters.AddWithValue("@Unidade", produto.Unidade);
                command.Parameters.AddWithValue("@Condicao", produto.Condicao);
                command.Parameters.AddWithValue("@CategoriaID", produto.Categoria.CategoriaID);

                command.ExecuteNonQuery();
            }
        }

        public List<Produto> RetornaTodosProdutos()
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string sQuery = " SELECT * FROM Produto LEFT JOIN Categoria ON Produto.CategoriaID = Caregoria.CategoriaID ";

            using SqlCommand command = new SqlCommand(sQuery, connection);

            using SqlDataReader reader = command.ExecuteReader();

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

            reader.Close();

            return produtos;
        }

        public Produto RetornaProduto(Guid produtoGuid)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            Produto produto = new Produto();
            connection.Open();

            string sQuery = " SELECT * FROM Produto WHERE Produto.ProdutoID = @ProdutoID ";

            using (SqlCommand command = new SqlCommand(sQuery, connection))
            {
                command.Parameters.AddWithValue("@ProdutoID", produtoGuid);

                produto = (Produto)command.ExecuteScalar();
            }

            return produto;
        }
    }
}
