using Volo.Abp.Modularity;

namespace Extraction
{
    [DependsOn(
        typeof(ExtractionApplicationModule),
        typeof(ExtractionDomainTestModule)
        )]
    public class ExtractionApplicationTestModule : AbpModule
    {

    }
}
