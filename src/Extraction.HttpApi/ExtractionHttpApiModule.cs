using Localization.Resources.AbpUi;
using Extraction.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Extraction
{
    [DependsOn(
        typeof(ExtractionApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class ExtractionHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(ExtractionHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<ExtractionResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
