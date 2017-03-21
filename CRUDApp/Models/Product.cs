namespace CRUDApp.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public int SupplierId { get; set; }

        public string SupplierName { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public System.DateTime LastUpdatedDate { get; set; }
    }
}
