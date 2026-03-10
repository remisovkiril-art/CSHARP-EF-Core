using System;
using OnlineStore.Configurations;
using OnlineStore.Context;
using OnlineStore.Services;
class Program
{
    static void Main()
    {
        var options = DbContextConfigurator.Configure();
        using var db = new StoreDbContext(options);
        var shop = new Shop(db);
        shop.CreateCategory("Electronics");
        var productService = new ProductService(db);
        productService.CreateProduct("Laptop", "Gaming laptop", 2000, 5, 1);
        productService.CreateProduct("Mouse", "Wireless mouse", 50, 0, 1);
        productService.CreateProduct("Keyboard", "Mechanical keyboard", 120, 10, 1);
        productService.CreateProduct("Monitor", "4K monitor", 800, 2, 1);
        productService.ShowOutOfStockProducts();
        productService.ShowTop3ExpensiveProducts();
        shop.GetProductsByCategory("Electronics");
        shop.GetCategoryByProduct("Laptop");
    }
}