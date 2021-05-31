﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Extraction.EntityFrameworkCore
{
    public class EfCoreExtractorInfoRepository : EfCoreRepository<IExtractionDbContext, ExtractorInfo, Guid>, IExtractorInfoRepository
    {
        public EfCoreExtractorInfoRepository(IDbContextProvider<IExtractionDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public override async Task<ExtractorInfo> GetAsync(Guid id, bool includeDetails = true, CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
                .IncludeDetails(includeDetails)
                .FirstOrDefaultAsync(x => x.Id == id, GetCancellationToken(cancellationToken));
        }

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
        public virtual async Task<List<ExtractorInfo>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting = null,
            bool includeDetails = true,
            Guid? extractorProviderId = null,
            string name = "",
            CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
                .IncludeDetails(includeDetails)
                .WhereIf(extractorProviderId.HasValue, item => item.ExtractorProviderId == extractorProviderId.Value)
                .WhereIf(!name.IsNullOrWhiteSpace(), item => item.Name.Contains(name))
                .OrderBy(sorting ?? nameof(ExtractorProvider.Name))
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        /// <summary>
        /// Get count
        /// </summary>
        /// <param name="extractorProviderId"></param>
        /// <param name="name"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<int> GetCountAsync(
            Guid? extractorProviderId = null,
            string name = "",
            CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
                .WhereIf(extractorProviderId.HasValue, item => item.ExtractorProviderId == extractorProviderId.Value)
                .WhereIf(!name.IsNullOrWhiteSpace(), item => item.Name == name)
                .CountAsync(GetCancellationToken(cancellationToken));
        }


    }
}