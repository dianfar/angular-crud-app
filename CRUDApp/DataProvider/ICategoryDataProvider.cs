namespace CRUDApp.DataProvider
{
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoryDataProvider
    {
        Task<IEnumerable<Category>> GetCategories();

        Task<Category> GetCategory(int id);

        Task AddCategory(Category category);

        Task UpdateCategory(Category category);

        Task DeleteCategory(int id);
    }
}
