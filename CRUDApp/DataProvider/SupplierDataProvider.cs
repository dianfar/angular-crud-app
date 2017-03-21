namespace CRUDApp.DataProvider
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;
    using Dapper;

    public class SupplierDataProvider : ISupplierDataProvider
    {
        private readonly string connectionString = "Server=localhost;Database=Tutorial;Trusted_Connection=True;";

        private SqlConnection sqlConnection;

        public async Task AddSupplier(Supplier supplier)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@SupplierId", supplier.SupplierId);
                dynamicParameters.Add("@Name", supplier.Name);
                dynamicParameters.Add("@Address", supplier.Address);
                dynamicParameters.Add("@ContactName", supplier.ContactName);
                await sqlConnection.ExecuteAsync(
                    "AddSupplier",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteSupplier(int id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@id", id);
                await sqlConnection.ExecuteAsync(
                    "DeleteSupplier",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Supplier> GetSupplier(int id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@id", id);
                return await sqlConnection.QuerySingleOrDefaultAsync<Supplier>(
                    "GetSupplier",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Supplier>> GetSuppliers()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<Supplier>(
                    "GetSuppliers",
                    null,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateSupplier(Supplier supplier)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@SupplierId", supplier.SupplierId);
                dynamicParameters.Add("@Name", supplier.Name);
                dynamicParameters.Add("@Address", supplier.Address);
                dynamicParameters.Add("@ContactName", supplier.ContactName);
                await sqlConnection.ExecuteAsync(
                    "UpdateSupplier",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
