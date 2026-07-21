using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RetailInventory
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Product> Products { get; set; } = new List<Product>();
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        
        // Lab 8: StockQuantity
        public int StockQuantity { get; set; }

        // Lab 11: One-to-One
        public virtual ProductDetail ProductDetail { get; set; }

        // Lab 11: Many-to-Many
        public virtual List<Tag> Tags { get; set; } = new List<Tag>();

        // Lab 15: Concurrency
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }

    // Lab 11
    public class ProductDetail
    {
        public int ProductDetailId { get; set; }
        public string WarrantyInfo { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }

    // Lab 11
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Product> Products { get; set; } = new List<Product>();
    }

    // Lab 12
    public class ProductDTO
    {
        public string Name { get; set; }
        public string CategoryName { get; set; }
    }
}
