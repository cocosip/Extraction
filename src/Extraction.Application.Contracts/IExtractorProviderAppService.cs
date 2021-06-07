using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Extraction
{
    public interface IExtractorProviderAppService : IApplicationService
    {
        /// <summary>
        /// Find by name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="includeDetails"></param>
        /// <returns></returns>
        Task<ExtractorProviderDto> FindByNameAsync(string name, bool includeDetails = true);

        /// <summary>
        /// 从缓存中获取配置信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<ExtractorProviderDto> FindByNameFromCacheAsync(string name);

        /// <summary>
        /// 根据Id查询配置
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includeDetails"></param>
        /// <returns></returns>
        Task<ExtractorProviderDto> GetAsync(Guid id, bool includeDetails = true);

        /// <summary>
        /// 提取器管道分页查询
        /// </summary>
        /// <param name="input"></param>
        /// <param name="includeDetails"></param>
        /// <returns></returns>
        Task<PagedResultDto<ExtractorProviderDto>> GetPagedListAsync(ExtractorProviderPagedRequestDto input, bool includeDetails = true);

        /// <summary>
        /// 创建提取管道
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<Guid> CreateAsync(CreateExtractorProviderDto input);

        /// <summary>
        /// 修改提取管道
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task UpdateAsync(Guid id, UpdateExtractorProviderDto input);

        /// <summary>
        /// 删除提取管道
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// 添加管道资源
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<Guid> CreateResourceAsync(Guid id, CreateExtractorProviderResourceDto input);

        /// <summary>
        /// 删除管道资源
        /// </summary>
        /// <param name="id"></param>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        Task DeleteResourceAsync(Guid id, Guid resourceId);

        /// <summary>
        /// 创建参数定义 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<Guid> CreateParameterDefinationAsync(Guid id, CreateParameterDefinationDto input);

        /// <summary>
        /// 删除参数定义
        /// </summary>
        /// <param name="id"></param>
        /// <param name="parameterDefinationId"></param>
        /// <returns></returns>
        Task DeleteParameterDefinationAsync(Guid id, Guid parameterDefinationId);

        /// <summary>
        /// 更新参数定义
        /// </summary>
        /// <param name="id"></param>
        /// <param name="parameterDefinationId"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task UpdateParameterDefinationAsync(Guid id, Guid parameterDefinationId, UpdateParameterDefinationDto input);
    }
}
