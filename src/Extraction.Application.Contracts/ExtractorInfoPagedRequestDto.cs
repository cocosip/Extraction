using Volo.Abp.Application.Dtos;

namespace Extraction
{
    public class ExtractorInfoPagedRequestDto : PagedAndSortedResultRequestDto
    {
        public string Name { get; set; }
    }
}
