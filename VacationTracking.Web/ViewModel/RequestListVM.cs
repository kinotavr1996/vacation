using System.Collections.Generic;

namespace VacationTracking.Web.ViewModel
{
    public class RequestListVM
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public List<RequestGridModel> Items { get; set; }
        public string Filter { get; set; }
        public GridOrder Order { get; set; }

        public RequestListVM()
        {
            Order = new GridOrder();
            Items = new List<RequestGridModel>();
            PageSize = 4;
            Page = 1;
        }
        public bool HasPreviousPage {
            get
            {
                return (Page > 1);
            }
        }

        public bool HasNextPage {
            get
            {
                return (Page < TotalPages);
            }
        }
    }
}
