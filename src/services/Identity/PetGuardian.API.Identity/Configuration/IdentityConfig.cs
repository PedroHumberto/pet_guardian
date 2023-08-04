using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetGuardian.API.Identity.Data;

namespace PetGuardian.API.Identity.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}