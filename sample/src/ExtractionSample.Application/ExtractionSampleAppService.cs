using System;
using System.Collections.Generic;
using System.Text;
using ExtractionSample.Localization;
using Volo.Abp.Application.Services;

namespace ExtractionSample
{
    /* Inherit your application services from this class.
     */
    public abstract class ExtractionSampleAppService : ApplicationService
    {
        protected ExtractionSampleAppService()
        {
            LocalizationResource = typeof(ExtractionSampleResource);
        }
    }
}
