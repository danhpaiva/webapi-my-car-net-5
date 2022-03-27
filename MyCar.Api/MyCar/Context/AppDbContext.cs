using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyCar.Models;
using System.IO;

namespace MyCar.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connectionString = configuration.GetConnectionString("ServerConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
    :   base(options)
        { }
    }
}
