using System.Collections.Generic;
using VacationTracking.Data.Models;

namespace VacationTracking.Repository
{
    public interface IVacationPolicyRepository : IRepository<VacationPolicy>
	{
        /// <summary>
        /// Get VacationPolicy
        /// </summary>
        /// <param name="id">VacationPolicy Id</param>
        /// <returns>Return a Employee object</returns>
        VacationPolicy GetById(int id);

        /// <summary>
        /// Get VacationPolicy list
        /// </summary>
        /// <returns>Return a Employee collection</returns>
        IEnumerable<VacationPolicy> GetVacationPolicies();
    }
}
