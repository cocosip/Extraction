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
    }
}
