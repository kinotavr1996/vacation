using System;
namespace VacationTracking.Data.Models
{
    public class VacationRequest
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Employee Id
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Approved by manager
        /// </summary>
        public bool Approved { get; set; }

        /// <summary>
        /// Start date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// End date
        /// </summary>
        public DateTime EndDate { get; set; }

        public Employee Employee { get; set; }
    }
}