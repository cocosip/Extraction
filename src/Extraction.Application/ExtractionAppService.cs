using Extraction.Localization;
using Volo.Abp.Application.Services;

namespace Extraction
{
    public abstract class ExtractionAppService : ApplicationService
    {
        protected ExtractionAppService()
        {
            LocalizationResource = typeof(ExtractionResource);
            ObjectMapperContext = typeof(ExtractionApplicationModule);
        }
    }
}
