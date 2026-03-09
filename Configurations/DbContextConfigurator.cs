using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnlineStore.Context;
namespace OnlineStore.Configurations
{
    public static class DbContextConfigurator
    {
        public static DbContextOptions<StoreDbContext> Configure()
        {
            var optionsBuilder = new DbContextOptionsBuilder<StoreDbContext>();

            optionsBuilder.UseSqlServer(
                "Server=DESKTOP-A0SJJUP\\SQLEXPRESS;Database=academyPV521;Trusted_Connection=True;TrustServerCertificate=True;");
            return optionsBuilder.Options;
        }
    }
}