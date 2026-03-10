using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
namespace OnlineStore.Context
{
    public class StoreDbContextFactory : IDesignTimeDbContextFactory<StoreDbContext>
    {
        public StoreDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("MSSQLConnection");
            var optionsBuilder = new DbContextOptionsBuilder<StoreDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new StoreDbContext(optionsBuilder.Options);
        }
    }
}