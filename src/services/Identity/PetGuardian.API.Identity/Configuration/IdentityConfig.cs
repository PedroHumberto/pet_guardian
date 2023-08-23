using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetGuardian.API.Identity.Data;
using PetGuardian.API.Identity.Models;
using PetGuardian.API.Identity.Services.Interfaces;
using PetGuardian.API.Identity.Services;

namespace PetGuardian.API.Identity.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();


            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();


            return services;
        }
    }
}