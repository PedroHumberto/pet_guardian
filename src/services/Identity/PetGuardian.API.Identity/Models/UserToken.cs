using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PetGuardian.API.Identity.Models
{
    public class UserToken : IdentityUser
    {
        public string Id { get; set; }

        public string Email { get; set; }

    }
}
