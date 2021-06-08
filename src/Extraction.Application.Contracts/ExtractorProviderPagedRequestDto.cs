using System;
using Volo.Abp.Application.Dtos;

namespace Extraction
{
    public class ExtractorProviderPagedRequestDto : PagedAndSortedResultRequestDto
    {
        public string Name { get; set; }

        public string ProviderName { get; set; }
    }
}
