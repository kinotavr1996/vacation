using System.ComponentModel.DataAnnotations;

namespace VacationTracking.Web.ViewModel
{
    public class LoginVM
    {
        public LoginVM()
        {
        }
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
