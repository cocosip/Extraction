using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Caching;

namespace Extraction
{
    public class ExtractorProviderAppService : ExtractionAppService, IExtractorProviderAppService
    {
        protected IExtractorProviderRepository ExtractorProviderRepository { get; }
        protected IDistributedCache<ExtractorProviderDto> ExtractorProviderCache { get; }
        public ExtractorProviderAppService(
            IExtractorProviderRepository extractorProviderRepository,
            IDistributedCache<ExtractorProviderDto> extractorProviderCache)
        {
            ExtractorProviderRepository = extractorProviderRepository;
            ExtractorProviderCache = extractorProviderCache;
        }

        /// <summary>
        /// Find by name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="includeDetails"></param>
        /// <returns></returns>
        public virtual async Task<ExtractorProviderDto> FindByNameAsync(string name, bool includeDetails = true)
        {
            var extractorProvider = await ExtractorProviderRepository.FindByNameAsync(name, includeDetails);
            return ObjectMapper.Map<ExtractorProvider, ExtractorProviderDto>(extractorProvider);
        }

        /// <summary>
        /// 从缓存中获取配置信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public virtual async Task<ExtractorProviderDto> FindByNameFromCacheAsync(string name)
        {
            var extractorProviderDto = await ExtractorProviderCache.GetOrAddAsync(
                name,
                async () =>
                {
                    return await FindByNameAsync(name, true);
                },
                hideErrors: false);
            return extractorProviderDto;
        }

        /// <summary>
        /// 根据Id查询配置
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includeDetails"></param>
        /// <returns></returns>
        public virtual async Task<ExtractorProviderDto> GetAsync(Guid id, bool includeDetails = true)
        {
            var extractorProvider = await ExtractorProviderRepository.GetAsync(id, includeDetails);
            return ObjectMapper.Map<ExtractorProvider, ExtractorProviderDto>(extractorProvider);
        }

        /// <summary>
        /// 提取器管道分页查询
        /// </summary>
        /// <param name="input"></param>
        /// <param name="includeDetails"></param>
        /// <returns></returns>
        public virtual async Task<PagedResultDto<ExtractorProviderDto>> GetPagedListAsync(
            ExtractorProviderPagedRequestDto input,
            bool includeDetails = true)
        {
            var count = await ExtractorProviderRepository.GetCountAsync(input.Name);
            var extractorProviders = await ExtractorProviderRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                includeDetails,
                input.Name);

            return new PagedResultDto<ExtractorProviderDto>(
                count,
                ObjectMapper.Map<List<ExtractorProvider>, List<ExtractorProviderDto>>(extractorProviders)
              );
        }

        //public virtual async Task<Guid> CreateAsync(CreateExtractorProviderDto input)
        //{

        //}

    }
}
