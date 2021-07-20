using ExtractionSample.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace ExtractionSample.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(ExtractionSampleEntityFrameworkCoreDbMigrationsModule),
        typeof(ExtractionSampleApplicationContractsModule)
        )]
    public class ExtractionSampleDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
