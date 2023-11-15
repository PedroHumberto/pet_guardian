using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetGuadian.API.Data;
using PetGuadian.API.Data.Repositories;
using PetGuadian.Application.Commands.AddressCommand;
using PetGuadian.Application.Commands.PetsCommand;
using PetGuadian.Application.Commands.UserCommands;
using PetGuadian.Application.Handlers;
using PetGuadian.Application.Handlers.Contracts;
using PetGuadian.Application.Services;
using PetGuadian.Application.Services.Interfaces;
using PetGuardian.Domain.Repositories;

namespace PetGuadian.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            
            //Dependency Injections
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IPetRepository, PetRepository>();

            //HANDLERS
            services.AddScoped<AddressHandler, AddressHandler>();
            services.AddScoped<UserHandler, UserHandler>();
            services.AddScoped<PetHandler, PetHandler>();

            
            services.AddScoped<AppContextDb>();
        }
    }
}