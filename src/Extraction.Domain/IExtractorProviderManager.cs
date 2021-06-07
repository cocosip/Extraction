using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Extraction
{
    public interface IExtractorProviderManager : IDomainService
    {
        /// <summary>
        /// 创建管道
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task CreateAsync(ExtractorProvider provider);

        /// <summary>
        /// 修改管道
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="title"></param>
        /// <param name="describe"></param>
        /// <returns></returns>
        Task UpdateAsync(Guid id, string name, string title, string describe);

        /// <summary>
        /// 添加资源
        /// </summary>
        /// <param name="id"></param>
        /// <param name="resource"></param>
        /// <returns></returns>
        Task CreateResourceAsync(Guid id, ExtractorProviderResource resource);

        /// <summary>
        /// 删除资源
        /// </summary>
        /// <param name="id"></param>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        Task DeleteResourceAsync(Guid id, Guid resourceId);

        /// <summary>
        /// 添加参数定义
        /// </summary>
        /// <param name="id"></param>
        /// <param name="parameterDefination"></param>
        /// <returns></returns>
        Task CreateParameterDefinationAsync(Guid id, ParameterDefination parameterDefination);

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
        /// <param name="parentId"></param>
        /// <param name="name"></param>
        /// <param name="parameterType"></param>
        /// <returns></returns>
        Task UpdateParameterDefinationAsync(Guid id, Guid parameterDefinationId, Guid? parentId, string name, int parameterType);
    }
}
