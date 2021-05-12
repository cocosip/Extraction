using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Extraction
{
    [DependsOn(
        typeof(ExtractionHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class ExtractionConsoleApiClientModule : AbpModule
    {
        
    }
}
