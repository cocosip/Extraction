using System;
using System.Threading.Tasks;

namespace Extraction
{
    public class ExtractResultInfoAppService : ExtractionAppService, IExtractResultInfoAppService
    {
        protected IExtractResultInfoRepository ExtractResultInfoRepository { get; }
        public ExtractResultInfoAppService(IExtractResultInfoRepository extractResultInfoRepository)
        {
            ExtractResultInfoRepository = extractResultInfoRepository;
        }

        /// <summary>
        /// 根据Id查询提取结果
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<ExtractResultInfoDto> GetAsync(Guid id)
        {
            var extractResultInfo = await ExtractResultInfoRepository.GetAsync(id, true);
            return ObjectMapper.Map<ExtractResultInfo, ExtractResultInfoDto>(extractResultInfo);
        }

    }
}
