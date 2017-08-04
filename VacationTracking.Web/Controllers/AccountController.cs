using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Security.Claims;
using VacationTracking.Data.Models;
using VacationTracking.Repository;
using System.Security.Cryptography;
using System.Text;
using VacationTracking.Web.ViewModel;
using VacationTracking.Data.Common;

namespace VacationTracking.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public AccountController(
            IEmployeeRepository employeeRepository
            )
        {
            _employeeRepository = employeeRepository;
        }
        public HttpStatusCode Index()
        {
            return HttpStatusCode.BadGateway;
        }
        [HttpGet]
        public HttpStatusCode Login()
        {
            return HttpStatusCode.OK;
        }

        [HttpPost]
        [Route("Login")]
        public Employee Login([FromBody]LoginVM login)
        {
            var model = new Employee { Email = login.Email, PasswordClear = login.Password };
            if (ModelState.IsValid)
            {
                using (var md5 = MD5.Create())
                {
                    var result = md5.ComputeHash(Encoding.ASCII.GetBytes(model.PasswordClear));
                    model.PasswordHash = Encoding.ASCII.GetString(result);
                }
                var user = _employeeRepository.GetEmployeeByLoginPassword(model.Email, model.PasswordHash);
                if (user != null)
                {
                    Authenticate(model.Email);
                }
                return user;
            }
            return model;
        }

        [Route("Logout")]
        public void Logout()
        {
            HttpContext.Authentication.SignOutAsync("Cookies");
        }

        [HttpPost]
        [Route("Registration")]
        public HttpStatusCode Register([FromBody]RegistrationVM register)
        {
            if (User.Identity.IsAuthenticated)
            {
                return HttpStatusCode.Forbidden;
            }
            if (ModelState.IsValid)
            {
                var model = new Employee
                {
                    Name = register.Name,
                    Surname = register.Surname,
                    Email = register.Email,
                    Phone = register.Phone,
                    PasswordClear = register.Password,
                    StartDate = DateTime.UtcNow,
                    RoleId = (int)EmployeeType.HR
                };
                var user = _employeeRepository.GetByEmail(model.Email);
                if (user == null)
                {
                    using (var md5 = MD5.Create())
                    {
                        var result = md5.ComputeHash(Encoding.ASCII.GetBytes(model.PasswordClear));
                        model.PasswordHash = Encoding.ASCII.GetString(result);
                    }
                    _employeeRepository.Add(model);
                    Authenticate(model.Email);
                    return HttpStatusCode.OK;
                }
                else
                    return HttpStatusCode.Unauthorized;
            }
            return HttpStatusCode.Unauthorized;
        }

        private void Authenticate(string userName)
        {
            var claims = new List<Claim>
                    {
                        new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
                    };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            HttpContext.Authentication.SignInAsync("Cookies", new ClaimsPrincipal(id));
        }

    }
}
