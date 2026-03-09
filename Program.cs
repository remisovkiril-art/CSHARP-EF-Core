using System;
using OnlineStore.Configurations;
using OnlineStore.Context;
using OnlineStore.Entities;
using OnlineStore.Services;
class Program
{
    static void Main()
    {
        var options = DbContextConfigurator.Configure();
        using var db = new StoreDbContext(options);
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();
        var category = new Category
        {
            Name = "Electronics"
        };
        db.Categories.Add(category);
        db.SaveChanges();
        var service = new ProductService(db);
        service.CreateProduct("Laptop", "Gaming laptop", 2000, 5, category.Id);
        service.CreateProduct("Mouse", "Wireless mouse", 50, 0, category.Id);
        service.CreateProduct("Keyboard", "Mechanical keyboard", 120, 10, category.Id);
        service.CreateProduct("Monitor", "4K monitor", 800, 2, category.Id);
        service.ChangeProductName(1, "Gaming Laptop");
        service.ChangeProductQuantity(2, 5);
        service.ShowOutOfStockProducts();
        service.ShowTop3ExpensiveProducts();
        service.DeleteProduct(3);
    }
}