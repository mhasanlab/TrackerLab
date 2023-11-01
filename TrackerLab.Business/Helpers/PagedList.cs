﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLab.Business.Extensions;

namespace TrackerLab.Business.Helpers
{
    public class PagedList<T> : List<T>
    {
        public PagedList(IEnumerable<T> items, int pageNumber, int pageSize, int totalItems)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            TotalItems = totalItems;
            AddRange(items);
        }

        public int PageNumber { get; init; }
        public int PageSize { get; init; }
        public int TotalItems { get; init; }
        public int TotalPages { get; init; }
        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            int totalItems;
            (source, totalItems) = await source.PaginateAsync(pageNumber, pageSize, cancellationToken);
            var items = await source.ToListAsync(cancellationToken);

            return new PagedList<T>(items, pageNumber, pageSize, totalItems);
        }
    }
}
