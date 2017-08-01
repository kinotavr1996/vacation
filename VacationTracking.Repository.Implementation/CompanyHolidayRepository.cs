using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VacationTracking.Data.Common.Pagination;
using VacationTracking.Data.Context;
using VacationTracking.Data.Models;



namespace VacationTracking.Repository.Implementation
{
    /// <summary>
    /// CompanyHolidayRepository implementation
    /// </summary>
    public class CompanyHolidayRepository : RepositoryBase<CompanyHoliday>, ICompanyHolidayRepository
    {
        public CompanyHolidayRepository(VacationContext context) : base(context)
        {
        }
        public CompanyHoliday GetById(int id)
        {
            return Find().AsNoTracking().FirstOrDefault(x => x.Id == id);
        }
        public override void Delete(int id)
        {
            var book = Find().SingleOrDefault(x => x.Id == id);
            Remove(book);
        }
        public IEnumerable<CompanyHoliday> GetCompanyHolidays()
        {
            return Find().Select(x => x).AsEnumerable();
        }

        public override void Edit(CompanyHoliday model)
        {
            var item = Find().SingleOrDefault(x => x.Id == model.Id);
            item.HolidayDate = model.HolidayDate;
            item.Name = model.Name;
            SaveChanges();
        }
    }
}
