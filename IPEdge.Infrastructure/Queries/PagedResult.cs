using System;
namespace IPEdge.Infrastructure.Queries
{
    public class PagedResult<T>
    {
        public List<T> Items { get; }
        public int PageNumber { get; }
        public int PageSize { get; }
        public int TotalCount { get; }

        public PagedResult(List<T> items, int pageNumber, int pageSize, int totalCount)
        {
            Items = items;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
        }
    }

}

