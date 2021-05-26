using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Extraction.EntityFrameworkCore
{
    [DependsOn(
        typeof(ExtractionDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
        )]
    public class ExtractionEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<ExtractionDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
                options.AddDefaultRepositories(true);
            });
        }
    }
}