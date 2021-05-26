using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Extraction.EntityFrameworkCore
{
    [ConnectionStringName(ExtractionDbProperties.ConnectionStringName)]
    public interface IExtractionDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */

        public DbSet<ExtractorProvider> ExtractorProviders { get; set; }
        public DbSet<ExtractorProviderResource> ExtractorProviderResources { get; set; }
        public DbSet<ExtractorInfo> ExtractorInfos { get; set; }
        public DbSet<ExtractorInfoResource> ExtractorInfoResources { get; set; }
        public DbSet<ExtractorInfoRule> ExtractorInfoRules { get; set; }
    }
}