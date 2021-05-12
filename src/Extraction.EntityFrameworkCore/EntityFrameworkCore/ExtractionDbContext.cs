using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Extraction.EntityFrameworkCore
{
    [ConnectionStringName(ExtractionDbProperties.ConnectionStringName)]
    public class ExtractionDbContext : AbpDbContext<ExtractionDbContext>, IExtractionDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public ExtractionDbContext(DbContextOptions<ExtractionDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureExtraction();
        }
    }
}