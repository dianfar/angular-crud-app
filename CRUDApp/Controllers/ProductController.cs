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
    public class ProductController : Controller
    {
        private IProductDataProvider productDataProvider;

        public ProductController(IProductDataProvider productDataProvider)
        {
            this.productDataProvider = productDataProvider;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await this.productDataProvider.GetProducts();
        }

        [HttpGet("{id}")]
        public async Task<Product> Get(int id)
        {
            return await this.productDataProvider.GetProduct(id);
        }

        [HttpPost]
        public async Task Post([FromBody]Product product)
        {
            await this.productDataProvider.AddProduct(product);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]Product product)
        {
            await this.productDataProvider.UpdateProduct(product);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this.productDataProvider.DeleteProduct(id);
        }
    }
}
