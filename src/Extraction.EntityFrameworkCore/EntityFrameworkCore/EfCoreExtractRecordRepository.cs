using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Extraction.EntityFrameworkCore
{
    public class EfCoreExtractRecordRepository : EfCoreRepository<IExtractionDbContext, ExtractRecord, Guid>, IExtractRecordRepository
    {
        public EfCoreExtractRecordRepository(IDbContextProvider<IExtractionDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        [NotNull]
        public override async Task<ExtractRecord> GetAsync(
            Guid id,
            bool includeDetails = true,
            CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
                .IncludeDetails(includeDetails)
                .FirstOrDefaultAsync(x => x.Id == id, GetCancellationToken(cancellationToken));
        }

        /// <summary>
        /// 根据记录编号查询数据
        /// </summary>
        /// <param name="recordNo"></param>
        /// <param name="includeDetails"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<ExtractRecord> FindByRecordNoAsync(
            string recordNo,
            bool includeDetails = true,
            CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
                .IncludeDetails(includeDetails)
                .FirstOrDefaultAsync(x => x.RecordNo == recordNo, GetCancellationToken(cancellationToken));
        }

        public async Task<IQueryable<ExtractRecord>> AsQueryableAsync()
        {
            return (await GetDbSetAsync()).AsQueryable();
        }
    }
}
