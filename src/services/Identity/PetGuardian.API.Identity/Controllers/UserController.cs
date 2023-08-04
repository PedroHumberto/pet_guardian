using Microsoft.AspNetCore.Mvc;
using PetGuardian.API.Identity.Models;

namespace PetGuardian.API.Identity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public IActionResult SingUp(CreateUser newUser)
        {
            return Ok(newUser);
        }
    }
}
