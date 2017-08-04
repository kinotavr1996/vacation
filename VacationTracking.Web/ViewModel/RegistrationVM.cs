using System.ComponentModel.DataAnnotations;

namespace VacationTracking.Web.ViewModel
{
    public class RegistrationVM
    {
        public RegistrationVM()
        {
        }
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
    }
}
