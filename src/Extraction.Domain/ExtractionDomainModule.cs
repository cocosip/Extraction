using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Extraction
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(ExtractionDomainSharedModule)
    )]
    public class ExtractionDomainModule : AbpModule
    {

    }
}
