using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VacationTracking.Data.Common.Pagination;
using VacationTracking.Data.Context;
using VacationTracking.Data.Models;
using VacationTracking.Repository.Implementation;

namespace VacationTracking.Repository.Implementations
{
    /// <summary>
    /// VacationRequestRepository implementation

    public class VacationRequestRepository : RepositoryBase<VacationRequest>, IVacationRequestRepository
    {
        public VacationRequestRepository(VacationContext context) : base(context)
        {
        }
        public VacationRequest GetById(int id)
        {
            return Find().AsNoTracking().FirstOrDefault(x => x.Id == id);
        }
        public override void Delete(int id)
        {
            var item = Find().SingleOrDefault(x => x.Id == id);
            Remove(item);
        }
        public IEnumerable<VacationRequest> GetByUserId(int id)
        {
            return Find().Where(x => x.EmployeeId == id);
        }
        public override void Edit(VacationRequest model)
        {
            var item = Find().SingleOrDefault(x => x.Id == model.Id);
            item.Approved = model.Approved;
            item.EndDate = model.EndDate;
            item.StartDate = model.StartDate;
            SaveChanges();
        }
        public IPagedList<VacationRequest> GetReportsPage(int page = 1, int pageSize = 20, Func<IQueryable<VacationRequest>, IQueryable<VacationRequest>> filter = null)
        {
            return base.GetPage(page, pageSize, (query) => (filter != null ? filter(query) : query));
        }
    }
}
