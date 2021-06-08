using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Extraction
{
    public interface IExtractorInfoRepository : IBasicRepository<ExtractorInfo, Guid>
    {
        /// <summary>
        /// 根据名称查询提取器信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="includeDetails"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ExtractorInfo> FindByNameAsync([NotNull] string name, bool includeDetails = true, CancellationToken cancellationToken = default);

        /// <summary>
        /// 根据名称查询提取器
        /// </summary>
        /// <param name="name"></param>
        /// <param name="expectedId"></param>
        /// <param name="includeDetails"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ExtractorInfo> FindExpectedByNameAsync(string name, Guid? expectedId = null, bool includeDetails = false, CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取全部的管道信息
        /// </summary>
        /// <param name="providerName"></param>
        /// <param name="includeDetails"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<ExtractorInfo>> GetAllAsync(string providerName = "", bool includeDetails = false, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get list
        /// </summary>
        /// <param name="skipCount"></param>
        /// <param name="maxResultCount"></param>
        /// <param name="sorting"></param>
        /// <param name="includeDetails"></param>
        /// <param name="providerName"></param>
        /// <param name="name"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<ExtractorInfo>> GetListAsync(int skipCount, int maxResultCount, string sorting = null, bool includeDetails = true, string providerName = "", string name = "", CancellationToken cancellationToken = default);

        /// <summary>
        /// Get count
        /// </summary>
        /// <param name="providerName"></param>
        /// <param name="name"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> GetCountAsync(string providerName = "", string name = "", CancellationToken cancellationToken = default);
    }
}
