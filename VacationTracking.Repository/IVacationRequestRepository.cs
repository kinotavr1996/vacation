using System;
using System.Collections.Generic;
using System.Linq;
using VacationTracking.Data.Common.Pagination;
using VacationTracking.Data.Models;

namespace VacationTracking.Repository
{
    public interface IVacationRequestRepository : IRepository<VacationRequest>
	{
        VacationRequest GetById(int id);
        IEnumerable<VacationRequest> GetByUserId(int id);
        IPagedList<VacationRequest> GetReportsPage(int page = 1, int pageSize = 20, Func<IQueryable<VacationRequest>, IQueryable<VacationRequest>> filter = null);
    }
}
