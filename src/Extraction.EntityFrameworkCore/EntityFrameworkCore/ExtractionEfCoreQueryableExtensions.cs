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

        public static IQueryable<ExtractResultInfo> IncludeDetails(
            this IQueryable<ExtractResultInfo> queryable,
            bool include = true)
        {
            if (!include)
            {
                return queryable;
            }
            return queryable
                .Include(x => x.Items);
        }

        public static IQueryable<ExtractResultItem> IncludeDetails(
            this IQueryable<ExtractResultItem> queryable,
            bool include = true)
        {
            if (!include)
            {
                return queryable;
            }
            return queryable
                .Include(x => x.Children);
        }


        public static IQueryable<ExtractRecord> IncludeDetails(
            this IQueryable<ExtractRecord> queryable,
            bool include = true)
        {
            if (!include)
            {
                return queryable;
            }
            return queryable
                .Include(x => x.Items)
                .Include(x => x.Indexs);
        }


        public static IQueryable<ExtractRecordItem> IncludeDetails(
            this IQueryable<ExtractRecordItem> queryable,
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
