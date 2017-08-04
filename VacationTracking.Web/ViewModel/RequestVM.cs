using System;

namespace VacationTracking.Web.ViewModel
{
    public class RequestVM
    {
        public int EmployeeId { get; set; }
        public bool Approved { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
