using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Extraction.EntityFrameworkCore
{
    public class ExtractionHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<ExtractionHttpApiHostMigrationsDbContext>
    {
        public ExtractionHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<ExtractionHttpApiHostMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Extraction"));

            return new ExtractionHttpApiHostMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
