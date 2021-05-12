using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Extraction.EntityFrameworkCore
{
    public class ExtractionHttpApiHostMigrationsDbContext : AbpDbContext<ExtractionHttpApiHostMigrationsDbContext>
    {
        public ExtractionHttpApiHostMigrationsDbContext(DbContextOptions<ExtractionHttpApiHostMigrationsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureExtraction();
        }
    }
}
