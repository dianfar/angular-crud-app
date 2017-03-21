namespace CRUDApp.DataProvider
{
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductDataProvider
    {
        Task<IEnumerable<Product>> GetProducts();

        Task<Product> GetProduct(int id);

        Task AddProduct(Product product);

        Task UpdateProduct(Product product);

        Task DeleteProduct(int id);
    }
}
