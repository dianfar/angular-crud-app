namespace CRUDApp.DataProvider
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;
    using Dapper;

    public class CategoryDataProvider : ICategoryDataProvider
    {
        private readonly string connectionString = "Server=localhost;Database=Tutorial;Trusted_Connection=True;";

        private SqlConnection sqlConnection;

        public async Task AddCategory(Category category)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@CategoryId", category.CategoryId);
                dynamicParameters.Add("@Name", category.CategoryName);
                await sqlConnection.ExecuteAsync(
                    "AddCategory",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteCategory(int id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@id", id);
                await sqlConnection.ExecuteAsync(
                    "DeleteCategory",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<Category>(
                    "GetCategories",
                    null,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Category> GetCategory(int id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@id", id);
                return await sqlConnection.QuerySingleOrDefaultAsync<Category>(
                    "GetCategory",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateCategory(Category category)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@CategoryId", category.CategoryId);
                dynamicParameters.Add("@Name", category.CategoryName);
                await sqlConnection.ExecuteAsync(
                    "UpdateCategory",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
