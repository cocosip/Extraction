using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Extraction.EntityFrameworkCore
{
    public class EfCoreExtractResultInfoRepository : EfCoreRepository<IExtractionDbContext, ExtractResultInfo, Guid>, IExtractResultInfoRepository
    {
        public EfCoreExtractResultInfoRepository(IDbContextProvider<IExtractionDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        [NotNull]
        public override async Task<ExtractResultInfo> GetAsync(
            Guid id,
            bool includeDetails = true,
            CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
                .IncludeDetails(includeDetails)
                .FirstOrDefaultAsync(x => x.Id == id, GetCancellationToken(cancellationToken));
        }

        /// <summary>
        /// 根据结果编号查询
        /// </summary>
        /// <param name="resultNo"></param>
        /// <param name="includeDetails"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<ExtractResultInfo> FindByResultNoAsync(
            string resultNo,
            bool includeDetails = true,
            CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
                .IncludeDetails(includeDetails)
                .FirstOrDefaultAsync(x => x.ResultNo == resultNo, GetCancellationToken(cancellationToken));
        }

    }
}
