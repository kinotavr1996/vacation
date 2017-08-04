using System.Collections.Generic;

namespace VacationTracking.Web.ViewModel
{
    public class PagedListViewModel<T> : List<T>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }

        public List<T> Items { get; set; }

        public string Filter { get; set; }

        public GridOrder Order { get; set; }

        public PagedListViewModel()
        {
            Order = new GridOrder();
            Items = new List<T>();
            PageSize = 4;
            Page = 1;
        }
        public bool HasPreviousPage
        {
            get
            {
                return (Page > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (Page < TotalPages);
            }
        }
    }
}
