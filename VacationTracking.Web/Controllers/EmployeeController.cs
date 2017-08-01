using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using VacationTracking.Data.Models;
using VacationTracking.Repository;
using System.Security.Claims;
using VacationTracking.Data.Common;
using System.Linq;
using System;

namespace VacationTracking.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ICompanyHolidayRepository _companyRepository;
        private readonly IVacationRequestRepository _vacationRequestRepository;
        private readonly IVacationPolicyRepository _vacationPolicyRepository;


        public EmployeeController(
            IEmployeeRepository employeeRepository,
            ICompanyHolidayRepository companyRepository,
            IVacationRequestRepository vacationRequestRepository,
            IVacationPolicyRepository vacationPolicyRepository

            )
        {
            _employeeRepository = employeeRepository;
            _companyRepository = companyRepository;
            _vacationRequestRepository = vacationRequestRepository;
            _vacationPolicyRepository = vacationPolicyRepository;
        }
        [HttpGet]
        public IEnumerable<CompanyHoliday> GetCompanyHoliday()
        {
            return _companyRepository.GetCompanyHolidays();
        }
        [Authorize]
        [HttpGet]
        public IEnumerable<VacationRequest> GetUserRequests(int id)
        {
            var model = _employeeRepository.GetById(id);
            var list = new List<VacationRequest>();
            if (model != null)
            {
                list.AddRange(_vacationRequestRepository.GetByUserId(id));
            }
            return list;
        }
        [Authorize]
        [HttpPost]
        public void PostRequest(VacationRequest model)
        {
            var user = _employeeRepository.GetByEmail(User.Identity.Name);
            if (ModelState.IsValid)
            {
                var list = _vacationRequestRepository.GetByUserId(user.Id).ToList();
                var validRequests = list.Where(x => x.EndDate <= DateTime.Now && x.Approved);
                var totalDays = 0.0;
                foreach (var item in validRequests)
                {
                    totalDays += (item.EndDate - item.StartDate).TotalDays;
                }
                var currYearVacPolicy = _vacationPolicyRepository.Get().Where(x => x.ServiceYears == DateTime.Now.Year).FirstOrDefault();
                if (currYearVacPolicy.ServiceYears < totalDays + (model.EndDate - model.StartDate).TotalDays)
                {
                    model.Approved = false;
                }
                _vacationRequestRepository.Add(model);
            }
        }
        [Authorize]
        [HttpPost]
        public void ApproveRequest(VacationRequest model)
        {
            var user = _employeeRepository.GetByEmail(User.Identity.Name);
            if(user.RoleId == (int)EmployeeType.HR)
            {
                model.Approved = true;
                _vacationRequestRepository.Edit(model);
            }
        }
        [Authorize]
        public IEnumerable<Employee> GetEmployees(Employee model)
        {
            var list = new List<Employee>();
            if (model.RoleId == (int)EmployeeType.HR)
            {
                list.AddRange(_employeeRepository.GetAll());
            }
            else
            {
                list.Add(_employeeRepository.GetByEmail(model.Email));
            }
            return list;
        }

        [Authorize]
        public Employee Get(int id)
        {
            var model = _employeeRepository.GetById(id);
            return model;
        }
    }
}
