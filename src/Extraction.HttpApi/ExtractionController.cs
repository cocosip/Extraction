using Extraction.Localization;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Extraction
{
    public abstract class ExtractionController : AbpController, IRemoteService
    {
        protected ExtractionController()
        {
            LocalizationResource = typeof(ExtractionResource);
        }
    }
}
