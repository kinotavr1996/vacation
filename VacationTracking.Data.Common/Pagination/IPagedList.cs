using System.Collections.Generic;

namespace VacationTracking
    
    .Data.Common.Pagination
{
    public interface IPagedList<T> : IReadOnlyList<T>
    {
        int TotalCount { get; }
        int Page { get; }
        int PageSize { get; }
    }
}
