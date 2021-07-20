using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace ExtractionSample.EntityFrameworkCore
{
    [DependsOn(
        typeof(ExtractionSampleEntityFrameworkCoreModule)
        )]
    public class ExtractionSampleEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<ExtractionSampleMigrationsDbContext>();
        }
    }
}
