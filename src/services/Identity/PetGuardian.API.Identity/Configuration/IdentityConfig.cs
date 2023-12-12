using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetGuardian.API.Identity.Data;
using PetGuardian.API.Identity.Models;
using PetGuardian.API.Identity.Services.Interfaces;
using PetGuardian.API.Identity.Services;
using PetGuardian.API.Identity.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;

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



            //AppSettings Config
            var appSettingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            //--------------

            services.AddAuthentication(opts =>
            {
                opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opts =>
            {
                opts.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = appSettings.Audience,
                    ValidIssuer = appSettings.Issuer,
                    ClockSkew = TimeSpan.Zero
                };
            });

            /* To use in future, maybe...
            services.AddAuthorization(opts =>
            {
                opts.AddPolicy("MinAge", policy => policy.AddRequirements(new MinimumAge(18))
                );
            });*/

            services.AddSingleton<IAuthorizationHandler, AgeAuthorization>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}