using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FornecedoresApp.Infrastructure
{
    public class FornecedoresDbContextFactory : IDesignTimeDbContextFactory<FornecedoresDbContext>
    {
        public FornecedoresDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("FornecedoresDB");

            var optionsBuilder = new DbContextOptionsBuilder<FornecedoresDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new FornecedoresDbContext(optionsBuilder.Options);
        }
    }
}
