using System;
using System.Linq;
using OnlineStore.Context;
using OnlineStore.Entities;
namespace OnlineStore.Services
{
    public class Shop
    {
        private readonly StoreDbContext _db;
        public Shop(StoreDbContext db)
        {
            _db = db;
        }
        public void CreateCategory(string name)
        {
            var category = new Category { Name = name };

            _db.Categories.Add(category);
            _db.SaveChanges();

            Console.WriteLine("Category created.");
        }
        public void ShowCategories()
        {
            var categories = _db.Categories.ToList();

            foreach (var c in categories)
                Console.WriteLine($"{c.Id} - {c.Name}");
        }
        public void ShowProducts()
        {
            var products = _db.Products.ToList();

            foreach (var p in products)
                Console.WriteLine($"{p.Id} {p.Name} {p.Price}");
        }
        public void GetCategoryByProduct(string productName)
        {
            var product = _db.Products
                .Where(p => p.Name == productName)
                .Select(p => new
                {
                    ProductName = p.Name,
                    CategoryName = p.Category.Name
                })
                .FirstOrDefault();
            if (product != null)
                Console.WriteLine($"{product.ProductName} belongs to category {product.CategoryName}");
        }
        public void GetProductsByCategory(string categoryName)
        {
            var products = _db.Products
                .Where(p => p.Category.Name == categoryName)
                .ToList();
            Console.WriteLine($"Products in category {categoryName}:");
            foreach (var p in products)
                Console.WriteLine(p.Name);
        }
    }
}