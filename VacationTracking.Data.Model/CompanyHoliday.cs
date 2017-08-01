using System;

namespace VacationTracking.Data.Models
{
    public class CompanyHoliday
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Holiday Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Holiday Date
        /// </summary>
        public DateTime HolidayDate { get; set; }
    }
}
