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
        Task AddResourceAsync(Guid id, ExtractorProviderResource resource);

        /// <summary>
        /// 删除资源
        /// </summary>
        /// <param name="id"></param>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        Task RemoveResourceAsync(Guid id, Guid resourceId);
    }
}
