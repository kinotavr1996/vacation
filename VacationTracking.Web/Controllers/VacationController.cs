using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using VacationTracking.Data.Common;
using VacationTracking.Data.Models;
using VacationTracking.Repository;

namespace VacationTracking.Controllers
{
    [Route("api/[controller]")]
    public class VacationController : Controller
    {
        private readonly IVacationPolicyRepository _vacationRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public VacationController(
              IVacationPolicyRepository vacationRepository,
              IEmployeeRepository employeeRepository
            )
        {
            _vacationRepository = vacationRepository;
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public List<VacationPolicy> Get(Employee model)
        {
            return _vacationRepository.GetVacationPolicies().ToList();
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public HttpStatusCode Edit()
        {
            return HttpStatusCode.OK;
        }
        [HttpPost]
        public HttpStatusCode Post(VacationPolicy model)
        {
            if(model != null)
            {
                _vacationRepository.Add(model);
                return HttpStatusCode.OK;
            }
            return HttpStatusCode.BadRequest;
        }
    }
}
