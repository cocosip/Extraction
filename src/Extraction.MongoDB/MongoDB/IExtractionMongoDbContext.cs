using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Extraction.MongoDB
{
    [ConnectionStringName(ExtractionDbProperties.ConnectionStringName)]
    public interface IExtractionMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
