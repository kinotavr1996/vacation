using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VacationTracking.Data.Models
{
    public class Employee
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Surname
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Employee Type
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string PasswordClear { get; set; }

        /// <summary>
        /// PasswordHash
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required]
        [Display(Name = "Login")]
        public string Email { get; set; }

        /// <summary>
        /// Start date
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// End date
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Phone
        /// </summary>
        public string Phone { get; set; }

        public bool AutoLogon { get; set;  }

        public Role Role { get; set; }

        public List<VacationRequest> Requests { get; set; }
    }
}