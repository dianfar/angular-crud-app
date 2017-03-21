namespace CRUDApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using DataProvider;
    using Models;

    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private ICategoryDataProvider categoryDataProvider;

        public CategoryController(ICategoryDataProvider categoryDataProvider)
        {
            this.categoryDataProvider = categoryDataProvider;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
            return await this.categoryDataProvider.GetCategories();
        }

        [HttpGet("{id}")]
        public async Task<Category> Get(int id)
        {
            return await this.categoryDataProvider.GetCategory(id);
        }

        [HttpPost]
        public async Task Post([FromBody]Category value)
        {
            await this.categoryDataProvider.AddCategory(value);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]Category value)
        {
            await this.categoryDataProvider.UpdateCategory(value);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this.categoryDataProvider.DeleteCategory(id);
        }
    }
}
