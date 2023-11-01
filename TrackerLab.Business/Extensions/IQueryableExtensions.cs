using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TrackerLab.Shared.Enums;

namespace TrackerLab.Business.Extensions
{
    public static class IQueryableExtensions
    {
      
        public static async Task<(IQueryable<T> Query, int TotalItems)> PaginateAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize,
            CancellationToken cancellationToken)
        {
            var totalItems = await source.CountAsync(cancellationToken);

            var query = source.Skip(pageSize * (pageNumber - 1))
                .Take(pageSize);

            return (query, totalItems);
        }

        public static IOrderedQueryable<T> SortBy<T, TKey>(this IQueryable<T> source,
            Expression<Func<T, TKey>> sortOn, SortOrder sortOrder = SortOrder.Ascending)
        {
            return sortOrder == SortOrder.Ascending ? source.OrderBy(sortOn) : source.OrderByDescending(sortOn);
        }

        public static IOrderedQueryable<T> ThenSortBy<T, TKey>(this IOrderedQueryable<T> source,
            Expression<Func<T, TKey>> sortOn, SortOrder sortOrder = SortOrder.Ascending)
        {
            return sortOrder == SortOrder.Ascending ? source.ThenBy(sortOn) : source.ThenByDescending(sortOn);
        }
    }
}
