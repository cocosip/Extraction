using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Extraction
{
    [DependsOn(
        typeof(ExtractionApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class ExtractionHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Extraction";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(ExtractionApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
