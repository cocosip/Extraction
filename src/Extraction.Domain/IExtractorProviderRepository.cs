using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Extraction
{

    public interface IExtractorProviderRepository : IBasicRepository<ExtractorProvider, Guid>
    {
        /// <summary>
        /// Find by name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="includeDetails"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ExtractorProvider> FindByNameAsync([NotNull] string name, bool includeDetails = true, CancellationToken cancellationToken = default);

        /// <summary>
        /// Find expected by name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="expectedId"></param>
        /// <param name="includeDetails"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ExtractorProvider> FindExpectedByNameAsync(string name, Guid? expectedId = null, bool includeDetails = false, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all
        /// </summary>
        /// <param name="includeDetails"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<ExtractorProvider>> GetAllAsync(bool includeDetails = true, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get list
        /// </summary>
        /// <param name="skipCount"></param>
        /// <param name="maxResultCount"></param>
        /// <param name="sorting"></param>
        /// <param name="includeDetails"></param>
        /// <param name="name"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<ExtractorProvider>> GetListAsync(int skipCount, int maxResultCount, string sorting = null, bool includeDetails = true, string name = "", CancellationToken cancellationToken = default);

        /// <summary>
        /// Get count
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> GetCountAsync(string name = "", CancellationToken cancellationToken = default);


    }
}
