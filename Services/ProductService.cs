using System;
using System.Linq;
using OnlineStore.Context;
using OnlineStore.Entities;
namespace OnlineStore.Services
{
    public class ProductService
    {
        private readonly StoreDbContext _db;
        public ProductService(StoreDbContext db)
        {
            _db = db;
        }
        public void CreateProduct(string name, string description, decimal price, int quantity, int categoryId)
        {
            var product = new Product
            {
                Name = name,
                Description = description,
                Price = price,
                StockQuantity = quantity,
                CategoryId = categoryId
            };
            _db.Products.Add(product);
            _db.SaveChanges();

            Console.WriteLine("Product created.");
        }
        public void ChangeProductName(int id, string newName)
        {
            var product = _db.Products.Find(id);

            if (product != null)
            {
                product.Name = newName;
                _db.SaveChanges();
                Console.WriteLine("Product name updated.");
            }
        }
        public void ChangeProductQuantity(int id, int quantity)
        {
            var product = _db.Products.Find(id);

            if (product != null)
            {
                product.StockQuantity = quantity;
                _db.SaveChanges();
                Console.WriteLine("Product quantity updated.");
            }
        }
        public void DeleteProduct(int id)
        {
            var product = _db.Products.Find(id);

            if (product != null)
            {
                _db.Products.Remove(product);
                _db.SaveChanges();
                Console.WriteLine("Product deleted.");
            }
        }
        public void ShowOutOfStockProducts()
        {
            var products = _db.Products
                .Where(p => p.StockQuantity == 0)
                .ToList();

            Console.WriteLine("Out of stock products:");
            foreach (var p in products)
            {
                Console.WriteLine($"{p.Name} - {p.Price}");
            }
        }
        public void ShowTop3ExpensiveProducts()
        {
            var products = _db.Products
                .OrderByDescending(p => p.Price)
                .Take(3)
                .ToList();
            Console.WriteLine("Top 3 most expensive products:");
            foreach (var p in products)
            {
                Console.WriteLine($"{p.Name} - {p.Price}");
            }
        }
    }
}