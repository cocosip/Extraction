using Extraction.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Extraction
{
    public abstract class ExtractionController : AbpController
    {
        protected ExtractionController()
        {
            LocalizationResource = typeof(ExtractionResource);
        }
    }
}
