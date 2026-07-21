using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EFCore.BulkExtensions;
using System.Collections.Generic;

namespace RetailInventory
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var context = new AppDbContext();
            
            // Ensure Database is created
            // await context.Database.EnsureCreatedAsync();

            Console.WriteLine("=== Lab 4: Inserting Initial Data ===");
            var electronics = new Category { Name = "Electronics_New" };
            var groceries = new Category { Name = "Groceries_New" };
            
            var product1 = new Product { Name = "Laptop", Price = 75000, Category = electronics };
            var product2 = new Product { Name = "Rice Bag", Price = 1200, Category = groceries };
            
            // We use standard Add instead of AddRangeAsync because we just want to demonstrate
            context.Categories.Add(electronics);
            context.Categories.Add(groceries);
            context.Products.AddRange(product1, product2);
            await context.SaveChangesAsync();

            Console.WriteLine("=== Lab 5: Retrieving Data ===");
            var allProducts = await context.Products.ToListAsync();
            foreach (var p in allProducts)
                Console.WriteLine($"{p.Name} - Rs.{p.Price}");

            var foundProduct = await context.Products.FindAsync(1);
            Console.WriteLine($"Found by ID 1: {foundProduct?.Name}");

            var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);
            Console.WriteLine($"Expensive: {expensive?.Name}");

            Console.WriteLine("=== Lab 6: Updating and Deleting Records ===");
            var productToUpdate = await context.Products.FirstOrDefaultAsync(p => p.Name == "Laptop");
            if (productToUpdate != null) {
                productToUpdate.Price = 70000;
                await context.SaveChangesAsync();
                Console.WriteLine("Updated Laptop price.");
            }

            var toDelete = await context.Products.FirstOrDefaultAsync(p => p.Name == "Rice Bag");
            if (toDelete != null) {
                context.Products.Remove(toDelete);
                await context.SaveChangesAsync();
                Console.WriteLine("Deleted Rice Bag.");
            }

            Console.WriteLine("=== Lab 7: Writing Queries with LINQ ===");
            var filtered = await context.Products
                .Where(p => p.Price > 1000)
                .OrderByDescending(p => p.Price)
                .ToListAsync();

            var productDTOs = await context.Products
                .Select(p => new ProductDTO { Name = p.Name, CategoryName = p.Category.Name })
                .ToListAsync();
            Console.WriteLine($"DTO Count: {productDTOs.Count}");

            Console.WriteLine("=== Lab 10: Loading Strategies ===");
            var eagerProducts = await context.Products
                .Include(p => p.Category)
                .ToListAsync();

            var explicitProduct = await context.Products.FirstOrDefaultAsync();
            if (explicitProduct != null) {
                await context.Entry(explicitProduct).Reference(p => p.Category).LoadAsync();
            }

            Console.WriteLine("=== Lab 13: Query Caching and Tracking ===");
            var noTrackingProducts = await context.Products
                .AsNoTracking()
                .ToListAsync();

            // Compiled Query
            var _expensiveProducts = EF.CompileAsyncQuery((AppDbContext ctx, decimal price) => 
                ctx.Products.Where(p => p.Price > price));
            
            var resultList = await _expensiveProducts(context, 10000).ToListAsync();
            Console.WriteLine($"Compiled query result count: {resultList.Count}");

            Console.WriteLine("=== Lab 14: Bulk Operations ===");
            // Create some products for bulk update
            var bulkProducts = new List<Product> {
                new Product { Name = "Bulk 1", Price = 10, CategoryId = 1 },
                new Product { Name = "Bulk 2", Price = 20, CategoryId = 2 }
            };
            await context.BulkInsertAsync(bulkProducts);
            Console.WriteLine("Bulk insert completed.");

            Console.WriteLine("=== Lab 15: Handling Concurrency ===");
            try {
                var pConcurrency = await context.Products.FirstOrDefaultAsync();
                if (pConcurrency != null) {
                    pConcurrency.Price += 10;
                    // In a real scenario, another process modifies the same row here
                    await context.SaveChangesAsync();
                }
            } catch (DbUpdateConcurrencyException) {
                Console.WriteLine("Concurrency conflict detected.");
            }
        }
    }
}
