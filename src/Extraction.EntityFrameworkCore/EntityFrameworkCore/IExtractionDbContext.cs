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
    }
}