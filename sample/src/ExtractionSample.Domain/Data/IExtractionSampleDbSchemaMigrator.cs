using System.Threading.Tasks;

namespace ExtractionSample.Data
{
    public interface IExtractionSampleDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
