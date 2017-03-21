namespace CRUDApp.DataProvider
{
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISupplierDataProvider
    {
        Task<IEnumerable<Supplier>> GetSuppliers();

        Task<Supplier> GetSupplier(int id);

        Task AddSupplier(Supplier supplier);

        Task UpdateSupplier(Supplier supplier);

        Task DeleteSupplier(int id);
    }
}
