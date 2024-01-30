using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetGuadian.API.Data;

namespace PetGuadian.API.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddSwaggerConfiguration();
            services.AddEndpointsApiExplorer();
            services.AddMemoryCache();

            services.AddCors(opts =>
            {
                opts.AddPolicy("AllowAnyOrigin", builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            var conn = configuration.GetConnectionString("DefaultConnection");


            services.AddDbContext<AppContextDb>(opts =>
            {
                opts.UseSqlServer(conn, options =>
                {
                    options.EnableRetryOnFailure(3, TimeSpan.FromSeconds(5), null);
                    options.MaxBatchSize(100);
                    options.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                });
                opts.LogTo(Console.WriteLine, LogLevel.Information);
            });

            return services;
        }
        public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
  
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseRouting();

            app.UseCors("AllowAnyOrigin");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            return app;
        }
    }
}