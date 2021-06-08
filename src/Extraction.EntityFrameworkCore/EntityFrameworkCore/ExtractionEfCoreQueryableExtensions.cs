using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Extraction.EntityFrameworkCore
{
    public static class ExtractionEfCoreQueryableExtensions
    {
        public static IQueryable<ExtractorProvider> IncludeDetails(
            this IQueryable<ExtractorProvider> queryable,
            bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                .Include(x => x.Resources)
                .Include(x => x.Definations);
        }

        public static IQueryable<ExtractorInfo> IncludeDetails(
            this IQueryable<ExtractorInfo> queryable, 
            bool include = true)
        {
            if (!include)
            {
                return queryable;
            }
            return queryable
                .Include(x => x.Resources)
                .Include(x => x.Rules);
        }

        public static IQueryable<ParameterDefination> IncludeDetails(
            this IQueryable<ParameterDefination> queryable,
            bool include = true)
        {
            if (!include)
            {
                return queryable;
            }
            return queryable
                .Include(x => x.Children);
        }
    }
}
