using ErpStudy.Domain.Entities;
using ErpStudy.Infrastructure.Data.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Text;

namespace ErpStudy.Infrastructure.Data.Repositories
{
    public class CategoryRepository(string connectionString) : ICategoryRepository
    {
        public async Task<Category?> CreateCategoryAsync(Category category)
        {
            await using SqlConnection connection = new(connectionString);
            connection.Open();

            StringBuilder stringBuilder = new();
            stringBuilder.Append(" INSERT INTO Category (Name) VALUES (@Name) ");
            stringBuilder.Append(" SELECT TOP 1 * FROM Category ");

            await using SqlCommand command = new(stringBuilder.ToString(), connection);
            command.Parameters.AddWithValue("@Name", category.Name);
            await using SqlDataReader reader = await command.ExecuteReaderAsync();

            Category? categoryResponse = null;

            if (await reader.ReadAsync())
            {
                categoryResponse = new Category
                {
                    Id = reader.GetGuid(0), Name = reader.GetString(reader.GetOrdinal("Name"))
                };
            }

            return categoryResponse;
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            await using SqlConnection connection = new SqlConnection(connectionString);

            await connection.OpenAsync();
            const string sQuery = " UPDATE Category SET Nome = @Name WHERE Id = @Id ";
            await using SqlCommand command = new SqlCommand(sQuery, connection);

            command.Parameters.AddWithValue("@Name", category.Name);
            command.Parameters.AddWithValue("@Id", category.Id);

            return await command.ExecuteNonQueryAsync() > 0;
        }

        public async Task<Category?> GetCategoryByIdAsync(Guid id)
        {
            await using SqlConnection connection = new(connectionString);

            await connection.OpenAsync();
            const string sQuery = " SELECT * FROM Category WHERE Id = @Id ";
            await using SqlCommand command = new(sQuery, connection);

            command.Parameters.AddWithValue("@Id", id);
            await using SqlDataReader reader = await command.ExecuteReaderAsync();

            Category? categoryResponse = null;

            if (await reader.ReadAsync())
            {
                categoryResponse = new Category
                {
                    Id = reader.GetGuid(0), Name = reader.GetString(reader.GetOrdinal("Name"))
                };
            }

            return categoryResponse;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            await using SqlConnection connection = new(connectionString);
            await connection.OpenAsync();

            const string sQuery = " SELECT * FROM Category ";
            await using SqlCommand command = new(sQuery, connection);
            await using SqlDataReader reader = await command.ExecuteReaderAsync();

            List<Category> listcategorias = [];

            while (await reader.ReadAsync())
            {
                Category categoria = new()
                {
                    Id = reader.GetGuid(0), Name = reader.GetString(reader.GetOrdinal("Name"))
                };

                listcategorias.Add(categoria);
            }

            return listcategorias;
        }

        public async Task<bool> DeleteCategoryAsync(Guid id)
        {
            await using SqlConnection connection = new(connectionString);
            await connection.OpenAsync();
            const string sQuery = " DELETE FROM Category WHERE Id = @Id";
            await using SqlCommand command = new(sQuery, connection);
            command.Parameters.AddWithValue("@Id", id);
            
            return await command.ExecuteNonQueryAsync() > 0;
        }
    }
}