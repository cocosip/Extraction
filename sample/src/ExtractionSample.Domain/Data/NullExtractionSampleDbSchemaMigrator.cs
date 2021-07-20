using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ExtractionSample.Data
{
    /* This is used if database provider does't define
     * IExtractionSampleDbSchemaMigrator implementation.
     */
    public class NullExtractionSampleDbSchemaMigrator : IExtractionSampleDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}