using System;
using System.Collections.Generic;
using System.Linq;
using VacationTracking.Data.Common.Pagination;
using VacationTracking.Data.Models;

namespace VacationTracking.Repository
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
      
        /// <summary>
        /// Get an Employee
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <returns>Return a Employee object</returns>
        Employee GetById(int id);

        /// <summary>
        /// Get an Employee
        /// </summary>
        /// <param name="login">login(email)</param>
        /// <param name="passwordHash">password hash</param>
        /// <returns>Return a Employee object</returns>
        Employee GetEmployeeByLoginPassword(string login, string passwordHash);

        /// <summary>
        /// Get Employee list
        /// </summary>
        /// <returns>Return a Employee collection</returns>
        List<Employee> GetAll();

        Employee GetByEmail(string email);

        IPagedList<Employee> GetReportsPage(int page = 1, int pageSize = 20, Func<IQueryable<Employee>, IQueryable<Employee>> filter = null);

    }
}
