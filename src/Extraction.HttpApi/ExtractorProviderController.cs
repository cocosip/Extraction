using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Extraction
{
    [RemoteService(Name = "Extraction")]
    [Area("Extraction")]
    [Route("api/extractor-provider")]
    public class ExtractorProviderController : ExtractionController
    {
        private readonly IExtractorProviderAppService _extractorProviderAppService;
        public ExtractorProviderController(IExtractorProviderAppService extractorProviderAppService)
        {
            _extractorProviderAppService = extractorProviderAppService;
        }


    }
}
