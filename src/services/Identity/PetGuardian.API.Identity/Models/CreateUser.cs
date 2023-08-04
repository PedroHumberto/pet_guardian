using System.ComponentModel.DataAnnotations;

namespace PetGuardian.API.Identity.Models
{
    public class CreateUser
    {
        [Required(ErrorMessage = "The field {0} it's necessary")]
        [EmailAddress(ErrorMessage = "The Field {0} is invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field {0} it's necessary")]
        [StringLength(100, ErrorMessage = "The field {0} needs {2} or {1} characters", MinimumLength = 6)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "The password doesn't match")]
        public string RePassword { get; set; }
    }
}
