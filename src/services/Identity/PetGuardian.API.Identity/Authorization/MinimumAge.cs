using Microsoft.AspNetCore.Authorization;

namespace PetGuardian.API.Identity.Authorization
{
    public class MinimumAge : IAuthorizationRequirement
    {
        public MinimumAge(int age) 
        {
            age = Age;    
        }
        public int Id { get; set; }
        public int Age { get; set; }
    }
}
