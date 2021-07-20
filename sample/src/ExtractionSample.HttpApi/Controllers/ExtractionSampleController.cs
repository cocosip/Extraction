using ExtractionSample.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ExtractionSample.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class ExtractionSampleController : AbpController
    {
        protected ExtractionSampleController()
        {
            LocalizationResource = typeof(ExtractionSampleResource);
        }
    }
}