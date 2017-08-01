using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VacationTracking.Data.Context;
using VacationTracking.Data.Models;
using VacationTracking.Repository.Implementation;

namespace VacationTracking.Repository.Implementations
{
    /// <summary>
    /// VacationPolicyRepository implementation
    /// </summary>
    public class VacationPolicyRepository : RepositoryBase<VacationPolicy>, IVacationPolicyRepository
    {
        public VacationPolicyRepository(VacationContext context) : base(context)
        {
        }
        public VacationPolicy GetById(int id)
        {
            return Find().AsNoTracking().FirstOrDefault(x => x.Id == id);
        }
        public override void Delete(int id)
        {
            var book = Find().SingleOrDefault(x => x.Id == id);
            Remove(book);
        }
        public IEnumerable<VacationPolicy> GetVacationPolicies()
        {
            return Find().Select(x => x).AsEnumerable();
        }
       
        public override void Edit(VacationPolicy model)
        {
            var item = Find().SingleOrDefault(x => x.Id == model.Id);
            item.Days = model.Days;
            item.ServiceYears = model.ServiceYears;
            SaveChanges();
        }
    }
}
