using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Extraction
{
    [DependsOn(
        typeof(ExtractionDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class ExtractionApplicationContractsModule : AbpModule
    {

    }
}
