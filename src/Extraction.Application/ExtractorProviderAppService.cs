using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Caching;

namespace Extraction
{
    public class ExtractorProviderAppService : ExtractionAppService, IExtractorProviderAppService
    {
        protected IExtractorProviderManager ExtractorProviderManager { get; }
        protected IExtractorProviderRepository ExtractorProviderRepository { get; }
        protected IDistributedCache<ExtractorProviderDto> ExtractorProviderCache { get; }
        public ExtractorProviderAppService(
            IExtractorProviderManager extractorProviderManager,
            IExtractorProviderRepository extractorProviderRepository,
            IDistributedCache<ExtractorProviderDto> extractorProviderCache)
        {
            ExtractorProviderManager = extractorProviderManager;
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
                });
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

        /// <summary>
        /// 创建提取管道
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public virtual async Task<Guid> CreateAsync(CreateExtractorProviderDto input)
        {
            var provider = new ExtractorProvider(
                GuidGenerator.Create(),
                input.Name,
                input.Title,
                input.Describe);

            await ExtractorProviderManager.CreateAsync(provider);
            return provider.Id;
        }

        /// <summary>
        /// 修改提取管道
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public virtual async Task UpdateAsync(Guid id, UpdateExtractorProviderDto input)
        {
            await ExtractorProviderManager.UpdateAsync(id, input.Name, input.Title, input.Describe);
        }

        /// <summary>
        /// 删除提取管道
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task DeleteAsync(Guid id)
        {
            await ExtractorProviderRepository.DeleteAsync(id);
        }

        /// <summary>
        /// 添加管道资源
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public virtual async Task<Guid> AddResourceAsync(Guid id, AddExtractorProviderResourceDto input)
        {
            var resource = new ExtractorProviderResource(
                GuidGenerator.Create(),
                id, input.Container,
                input.FileId,
                input.FileType,
                input.Order);

            await ExtractorProviderManager.AddResourceAsync(id, resource);
            return resource.Id;
        }

        /// <summary>
        /// 删除管道资源
        /// </summary>
        /// <param name="id"></param>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public virtual async Task RemoveResourceAsync(Guid id, Guid resourceId)
        {
            await ExtractorProviderManager.RemoveResourceAsync(id, resourceId);
        }

        //public virtual async Task<Guid> AddParameterDefinationAsync(Guid id)
        //{

        //}

    }
}
