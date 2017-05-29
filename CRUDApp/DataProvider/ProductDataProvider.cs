namespace CRUDApp.DataProvider
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;
    using Models;
    using Dapper;
    using System.Data;

    public class ProductDataProvider : IProductDataProvider
    {
        private readonly string connectionString = "Server=localhost;Database=Tutorial;Trusted_Connection=True;";

        private SqlConnection sqlConnection;

        public async Task AddProduct(Product product)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Name", product.Name);
                dynamicParameters.Add("@Price", product.Price);
                dynamicParameters.Add("@Quantity", product.Quantity);
                dynamicParameters.Add("@SupplierId", product.SupplierId);
                dynamicParameters.Add("@CategoryId", product.CategoryId);
                await sqlConnection.ExecuteAsync(
                    "AddProduct",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteProduct(int id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@productId", id);
                await sqlConnection.ExecuteAsync(
                    "DeleteProduct",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Product> GetProduct(int id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@id", id);
                return await sqlConnection.QuerySingleOrDefaultAsync<Product>(
                    "GetProduct", 
                    dynamicParameters, 
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<Product>(
                    "GetProducts",
                    null,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateProduct(Product product)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ProductId", product.ProductId);
                dynamicParameters.Add("@Name", product.Name);
                dynamicParameters.Add("@Price", product.Price);
                dynamicParameters.Add("@Quantity", product.Quantity);
                dynamicParameters.Add("@SupplierId", product.SupplierId);
                dynamicParameters.Add("@CategoryId", product.CategoryId);
                await sqlConnection.ExecuteAsync(
                    "UpdateProduct",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
