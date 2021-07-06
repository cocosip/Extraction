using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Caching;

namespace Extraction
{
    public class ExtractorInfoAppService : ExtractionAppService, IExtractorInfoAppService
    {
        protected IExtractorInfoManager ExtractorInfoManager { get; }
        protected IExtractorInfoRepository ExtractorInfoRepository { get; }
        protected IDistributedCache<ExtractorInfoDto> ExtractorInfoCache { get; }
        public ExtractorInfoAppService(
            IExtractorInfoManager extractorInfoManager,
            IExtractorInfoRepository extractorInfoRepository,
            IDistributedCache<ExtractorInfoDto> extractorInfoCache)
        {
            ExtractorInfoManager = extractorInfoManager;
            ExtractorInfoRepository = extractorInfoRepository;
            ExtractorInfoCache = extractorInfoCache;
        }

        /// <summary>
        /// 根据名称查询提取器信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="includeDetails"></param>
        /// <returns></returns>
        public virtual async Task<ExtractorInfoDto> FindByNameAsync(string name, bool includeDetails = true)
        {
            var extractorInfo = await ExtractorInfoRepository.FindByNameAsync(name, includeDetails);
            return ObjectMapper.Map<ExtractorInfo, ExtractorInfoDto>(extractorInfo);
        }

        ///// <summary>
        ///// 根据名称从缓存中获取提取器信息
        ///// </summary>
        ///// <param name="name"></param>
        ///// <param name="includeDetails"></param>
        ///// <returns></returns>
        //public virtual async Task<ExtractorInfoDto> FindByNameFromCacheAsync(string name, bool includeDetails = true)
        //{
        //    var extractorInfoDto = await ExtractorInfoCache.GetOrAddAsync(
        //     name,
        //     async () =>
        //     {
        //         return await FindByNameAsync(name, includeDetails);
        //     });
        //    return extractorInfoDto;
        //}

        /// <summary>
        /// 根据Id获取提取器信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includeDetails"></param>
        /// <returns></returns>
        public virtual async Task<ExtractorInfoDto> GetAsync(Guid id, bool includeDetails = true)
        {
            var extractorInfo = await ExtractorInfoRepository.GetAsync(id, includeDetails);
            return ObjectMapper.Map<ExtractorInfo, ExtractorInfoDto>(extractorInfo);
        }

        /// <summary>
        /// 提取器分页查询
        /// </summary>
        /// <param name="input"></param>
        /// <param name="includeDetails"></param>
        /// <returns></returns>
        public virtual async Task<PagedResultDto<ExtractorInfoDto>> GetPagedListAsync(
            ExtractorProviderPagedRequestDto input,
            bool includeDetails = true)
        {
            var count = await ExtractorInfoRepository.GetCountAsync(input.ProviderName, input.Name);
            var extractorInfos = await ExtractorInfoRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                includeDetails,
                input.ProviderName,
                input.Name);

            return new PagedResultDto<ExtractorInfoDto>(
                count,
                ObjectMapper.Map<List<ExtractorInfo>, List<ExtractorInfoDto>>(extractorInfos)
              );
        }

        /// <summary>
        /// 创建提取器
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public virtual async Task<Guid> CreateAsync(CreateExtractorInfoDto input)
        {
            var extractorInfo = new ExtractorInfo(
                GuidGenerator.Create(),
                input.ProviderName,
                input.Name,
                input.Match,
                input.Domain,
                input.Url,
                input.Describe);

            await ExtractorInfoManager.CreateAsync(extractorInfo);
            return extractorInfo.Id;
        }

        /// <summary>
        /// 修改提取器
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public virtual async Task UpdateAsync(Guid id, UpdateExtractorInfoDto input)
        {
            await ExtractorInfoManager.UpdateAsync(
                id,
                input.Name,
                input.Match,
                input.Domain,
                input.Url,
                input.Describe);
        }

        /// <summary>
        /// 删除提取器
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task DeleteAsync(Guid id)
        {
            await ExtractorInfoRepository.DeleteAsync(id);
        }

        /// <summary>
        /// 创建提取器资源
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public virtual async Task<Guid> CreateResourceAsync(Guid id, CreateExtractorInfoResourceDto input)
        {
            var extractorInfoResource = new ExtractorInfoResource(GuidGenerator.Create(), id, input.Container, input.FileId, input.FileType);

            await ExtractorInfoManager.CreateResourceAsync(id, extractorInfoResource);
            return extractorInfoResource.Id;
        }

        /// <summary>
        /// 删除提取器资源
        /// </summary>
        /// <param name="id"></param>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public virtual async Task DeleteResourceAsync(Guid id, Guid resourceId)
        {
            await ExtractorInfoManager.DeleteResourceAsync(id, resourceId);
        }

        /// <summary>
        /// 创建提取器规则
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public virtual async Task<Guid> CreateRuleAsync(Guid id, CreateExtractorInfoRuleDto input)
        {
            var extractorInfoRule = new ExtractorInfoRule(
                id,
                Guid.NewGuid(),
                input.ParameterDefinationId,
                input.SelectNodeType,
                input.NodeManipulationType,
                input.HandleStyle,
                input.XPathValue,
                input.PreHandlers,
                input.AfterHandlers,
                input.Describe);

            await ExtractorInfoManager.CreateRuleAsync(id, extractorInfoRule);
            return extractorInfoRule.Id;
        }

        /// <summary>
        /// 更新提取器规则
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ruleId"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public virtual async Task UpdateRuleAsync(Guid id, Guid ruleId, UpdateExtractorInfoRuleDto input)
        {
            await ExtractorInfoManager.UpdateRuleAsync(
                id,
                ruleId,
                input.ParameterDefinationId,
                input.SelectNodeType,
                input.NodeManipulationType,
                input.HandleStyle,
                input.XPathValue,
                input.PreHandlers,
                input.AfterHandlers,
                input.Describe);
        }

        /// <summary>
        /// 删除提取器规则
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ruleId"></param>
        /// <returns></returns>
        public virtual async Task DeleteRuleAsync(Guid id, Guid ruleId)
        {
            await ExtractorInfoManager.DeleteRuleAsync(id, ruleId);
        }

    }
}
