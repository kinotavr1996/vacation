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
using VacationTracking.Web.ViewModel;

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
        public IQueryable<Employee> ApplyFilter(IQueryable<Employee> query, string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
                return query.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper()) || s.Surname.ToUpper().Contains(searchString.ToUpper()));
            else
                return query;
        }
        public IQueryable<VacationRequest> ApplySortOrder(IQueryable<VacationRequest> query, string sortOrder, string direction)
        {
            switch (sortOrder)
            {
                case "endDate":
                    query = direction == "ASC" ? query.OrderBy(s => s.EndDate) : query.OrderByDescending(s => s.EndDate);
                    break;
                case "startDate":
                    query = direction == "ASC" ? query.OrderBy(s => s.StartDate) : query.OrderByDescending(s => s.StartDate);
                    break;
                default:
                    query = direction == "ASC" ? query.OrderBy(s => s.EndDate) : query.OrderByDescending(s => s.EndDate);
                    break;
            }
            return query;
        }
        [HttpGet]
        public IEnumerable<CompanyHoliday> GetCompanyHoliday()
        {
            return _companyRepository.GetCompanyHolidays();
        }

        [Route("List/{id}")]
        public ActionResult List([FromBody]int Id, [FromQuery]string sortOrder, [FromQuery]string direction, [FromQuery]string searchString, [FromQuery]string currentFilter, [FromQuery]int? page)
        {
            RequestListVM requestList = new RequestListVM();
            requestList.Filter = searchString;
            requestList.Order.Column = sortOrder ?? "name";
            requestList.Order.Direction = direction ?? "ASC";
            requestList.Page = page ?? 1;
            if (requestList.Filter != null)
                requestList.Page = 1;
            else
                requestList.Filter = currentFilter;
            var requests = _vacationRequestRepository.GetPage(requestList.Page, requestList.PageSize, (query) => ApplySortOrder(query, requestList.Order.Column, requestList.Order.Direction));
            if(Id > 0)
                if (_employeeRepository.GetById(Id).RoleId != (int)EmployeeType.Manager)
                    requests.Where(x => x.EmployeeId == Id).ToList();
            foreach (var c in requests)
            {
                var user = _employeeRepository.GetById(c.EmployeeId);
                requestList.Items.Add(new RequestGridModel { Id = c.Id, Approved = c.Approved,  Name = $"{user.Name} {user.Surname}", EndDate = c.EndDate, StartDate = c.StartDate });
            }
            requestList.TotalPages = (int)Math.Ceiling(requests.TotalCount / (double)requestList.PageSize);
            return Ok(requestList);
        }
        [Authorize]
        [HttpGet]
        [Route("GetOwnAll")]
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
        [HttpPost]
        [Route("Create")]
        public void PostRequest([FromBody]RequestVM request)
        {
            var user = _employeeRepository.GetById(request.EmployeeId);
            var model = new VacationRequest { StartDate = request.StartDate, EndDate = request.EndDate, EmployeeId = request.EmployeeId };
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
                if (currYearVacPolicy != null && currYearVacPolicy.ServiceYears < totalDays + (model.EndDate - model.StartDate).TotalDays)
                {
                    model.Approved = false;
                }
                _vacationRequestRepository.Add(model);
            }
        }
        [HttpGet]
        [Route("Approve/{id}")]
        public void ApproveRequest(int id)
        {
            var request = _vacationRequestRepository.GetById(id);
            var user = _employeeRepository.GetById(request.EmployeeId);
            var model = new VacationRequest { Id = request.Id, StartDate = request.StartDate, EndDate = request.EndDate, EmployeeId = request.EmployeeId };
            if (user.RoleId == (int)EmployeeType.HR)
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

        public Employee GetCurrentUser()
        {
            return _employeeRepository.GetByEmail(User.Identity.Name);
        }

        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            var model = _employeeRepository.GetById(id);
            return model;
        }
    }
}
