using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Extraction
{
    public interface IExtractResultInfoRepository : IBasicRepository<ExtractResultInfo, Guid>
    {
        /// <summary>
        /// 根据结果编号查询
        /// </summary>
        /// <param name="resultNo"></param>
        /// <param name="includeDetails"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ExtractResultInfo> FindByResultNoAsync(string resultNo, bool includeDetails = true, CancellationToken cancellationToken = default);


    }
}
