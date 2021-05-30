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
        /// Get list
        /// </summary>
        /// <param name="skipCount"></param>
        /// <param name="maxResultCount"></param>
        /// <param name="sorting"></param>
        /// <param name="includeDetails"></param>
        /// <param name="extractorProviderId"></param>
        /// <param name="name"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<ExtractorInfo>> GetListAsync(int skipCount, int maxResultCount, string sorting = null, bool includeDetails = true, Guid? extractorProviderId = null, string name = "", CancellationToken cancellationToken = default);

        /// <summary>
        /// Get count
        /// </summary>
        /// <param name="extractorProviderId"></param>
        /// <param name="name"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> GetCountAsync(Guid? extractorProviderId = null, string name = "", CancellationToken cancellationToken = default);
    }
}
