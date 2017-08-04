using System;
using System.Collections.Generic;
using System.Text;

namespace VacationTracking.Web.ViewModel
{
    public class RequestGridModel
    {
        public RequestGridModel()
        {
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Approved { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? StartDate { get; set; }
    }
}
