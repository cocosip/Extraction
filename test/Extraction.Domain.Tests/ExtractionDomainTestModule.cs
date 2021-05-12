using Extraction.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Extraction
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(ExtractionEntityFrameworkCoreTestModule)
        )]
    public class ExtractionDomainTestModule : AbpModule
    {
        
    }
}
