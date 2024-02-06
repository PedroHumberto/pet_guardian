using System.Reflection;
using MediatR;
using PetGuadian.API.Data;
using PetGuadian.API.Data.Repositories;
using PetGuadian.Application.Commands.Contracts;
using PetGuadian.Application.Commands.PetsCommand;
using PetGuadian.Application.Handlers;
using PetGuadian.Application.Queries.PetQueries;
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
            services.AddScoped<IMedicineService, MedicineService>();
            services.AddScoped<IMedicineRepository, MedicineRepository>();
            services.AddScoped<IVaccineRepository, VaccineRepository>();

            //HANDLERS
            services.AddScoped<AddressHandler, AddressHandler>();
            services.AddScoped<UserHandler, UserHandler>();
            services.AddScoped<PetHandler, PetHandler>();
            services.AddScoped<MedicineHandler, MedicineHandler>();

            //MEDIATR
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient<IRequestHandler<CreatePetCommand, ICommandResult>, PetHandler>();
            services.AddTransient<IRequestHandler<UpdatePetCommand, ICommandResult>, PetHandler>();
            services.AddTransient<IRequestHandler<DeletePetCommand, ICommandResult>, PetHandler>();

            //Queries
            services.AddTransient<IRequestHandler<FindAllPetsByUserIdCommand, ICommandResult>, PetHandler>();
            services.AddTransient<IRequestHandler<FindPetByIdCommand, ICommandResult>, PetHandler>();
            

            
            services.AddScoped<AppContextDb>();
        }
    }
}