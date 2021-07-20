using Volo.Abp.Modularity;

namespace ExtractionSample
{
    [DependsOn(
        typeof(ExtractionSampleApplicationModule),
        typeof(ExtractionSampleDomainTestModule)
        )]
    public class ExtractionSampleApplicationTestModule : AbpModule
    {

    }
}