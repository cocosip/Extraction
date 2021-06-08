using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Extraction
{
    public interface IExtractorInfoAppService : IApplicationService
    {
        /// <summary>
        /// 根据名称查询提取器信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="includeDetails"></param>
        /// <returns></returns>
        Task<ExtractorInfoDto> FindByNameAsync(string name, bool includeDetails = true);

        /// <summary>
        /// 根据名称从缓存中获取提取器信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="includeDetails"></param>
        /// <returns></returns>
        Task<ExtractorInfoDto> FindByNameFromCacheAsync(string name, bool includeDetails = true);

        /// <summary>
        /// 根据Id获取提取器信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includeDetails"></param>
        /// <returns></returns>
        Task<ExtractorInfoDto> GetAsync(Guid id, bool includeDetails = true);

        /// <summary>
        /// 提取器分页查询
        /// </summary>
        /// <param name="input"></param>
        /// <param name="includeDetails"></param>
        /// <returns></returns>
        Task<PagedResultDto<ExtractorInfoDto>> GetPagedListAsync(ExtractorProviderPagedRequestDto input, bool includeDetails = true);

        /// <summary>
        /// 创建提取器
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<Guid> CreateAsync(CreateExtractorInfoDto input);

        /// <summary>
        /// 修改提取器
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task UpdateAsync(Guid id, UpdateExtractorInfoDto input);

        /// <summary>
        /// 删除提取器
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// 创建提取器资源
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<Guid> CreateResourceAsync(Guid id, CreateExtractorInfoResourceDto input);

        /// <summary>
        /// 删除提取器资源
        /// </summary>
        /// <param name="id"></param>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        Task DeleteResourceAsync(Guid id, Guid resourceId);
    }
}
