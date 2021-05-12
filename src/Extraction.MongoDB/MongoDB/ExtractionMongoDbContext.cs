using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Extraction.MongoDB
{
    [ConnectionStringName(ExtractionDbProperties.ConnectionStringName)]
    public class ExtractionMongoDbContext : AbpMongoDbContext, IExtractionMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureExtraction();
        }
    }
}