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
    /// EmployeeRepository implementation
    /// </summary>

    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(VacationContext context) : base(context)
        {
        }
        public Employee GetById(int id)
        {
            return Find().AsNoTracking().FirstOrDefault(x => x.Id == id);
        }
        public override void Delete(int id)
        {
            var book = Find().SingleOrDefault(x => x.Id == id);
            Remove(book);
        }
        public Employee GetByEmail(string email)
        {
            return Find().Where(x => x.Email == email).FirstOrDefault();
        }
        public List<Employee> GetAll()
        {
            return Find().Select(x => x).ToList();
        }
        public Employee GetEmployeeByLoginPassword(string login, string passwordHash)
        {
            return Find().Where(x => x.Email == login && x.PasswordHash == passwordHash).FirstOrDefault();
        }
        public IPagedList<Employee> GetReportsPage(int page = 1, int pageSize = 20, Func<IQueryable<Employee>, IQueryable<Employee>> filter = null)
        {
            return base.GetPage(page, pageSize, (query) => (filter != null ? filter(query) : query));
        }
        public override void Edit(Employee model)
        {
            var item = Find().SingleOrDefault(x => x.Id == model.Id);
            item.Email = model.Email;
            item.Name = model.Name;
            item.Surname = model.Surname;
            item.StartDate = model.StartDate;
            item.Phone = model.Phone;
            item.PasswordHash = model.PasswordHash;
            item.PasswordClear = model.PasswordClear;
            SaveChanges();
        }
    }
}
