using ExtractionSample.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ExtractionSample
{
    [DependsOn(
        typeof(ExtractionSampleEntityFrameworkCoreTestModule)
        )]
    public class ExtractionSampleDomainTestModule : AbpModule
    {

    }
}