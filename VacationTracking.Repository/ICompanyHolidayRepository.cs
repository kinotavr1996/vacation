using System.Collections.Generic;
using VacationTracking.Data.Models;

namespace VacationTracking.Repository
{
    public interface ICompanyHolidayRepository : IRepository<CompanyHoliday>
	{
        IEnumerable<CompanyHoliday> GetCompanyHolidays();
    }
}
