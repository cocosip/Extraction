using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Extraction
{
    public interface IExtractRecordRepository : IBasicRepository<ExtractRecord, Guid>
    {
        /// <summary>
        /// 根据记录编号查询数据
        /// </summary>
        /// <param name="recordNo"></param>
        /// <param name="includeDetails"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ExtractRecord> FindByRecordNoAsync(string recordNo, bool includeDetails = true, CancellationToken cancellationToken = default);
    }
}
