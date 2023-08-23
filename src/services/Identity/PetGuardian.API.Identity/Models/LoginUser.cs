using System.ComponentModel.DataAnnotations;

namespace PetGuardian.API.Identity.Models
{
    public class LoginUser
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
