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
    public class SupplierController : Controller
    {
        private ISupplierDataProvider supplierDataProvider;

        public SupplierController(ISupplierDataProvider supplierDataProvider)
        {
            this.supplierDataProvider = supplierDataProvider;
        }

        [HttpGet]
        public async Task<IEnumerable<Supplier>> Get()
        {
            return await this.supplierDataProvider.GetSuppliers();
        }

        [HttpGet("{id}")]
        public async Task<Supplier> Get(int id)
        {
            return await this.supplierDataProvider.GetSupplier(id);
        }

        [HttpPost]
        public async Task Post([FromBody]Supplier value)
        {
            await this.supplierDataProvider.AddSupplier(value);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]Supplier value)
        {
            await this.supplierDataProvider.UpdateSupplier(value);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this.supplierDataProvider.DeleteSupplier(id);
        }
    }
}
