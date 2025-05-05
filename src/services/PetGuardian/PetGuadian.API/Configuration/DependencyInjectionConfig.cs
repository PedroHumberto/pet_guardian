using System.Reflection;
using MediatR;
using PetGuadian.API.Data;
using PetGuadian.API.Data.Repositories;
using PetGuadian.Application.Abstractions;
using PetGuadian.Application.Commands.AddressCommand;
using PetGuadian.Application.Commands.Contracts;
using PetGuadian.Application.Commands.ExamCommand;
using PetGuadian.Application.Commands.MedicineCommands;
using PetGuadian.Application.Commands.PetsCommand;
using PetGuadian.Application.Commands.UserCommands;
using PetGuadian.Application.Commands.VaccineCommands;
using PetGuadian.Application.Handlers.Adresses;
using PetGuadian.Application.Handlers.Exams;
using PetGuadian.Application.Handlers.Medicines;
using PetGuadian.Application.Handlers.Pets;
using PetGuadian.Application.Handlers.Users;
using PetGuadian.Application.Handlers.Vaccines;
using PetGuadian.Application.Queries.AddressQueries;
using PetGuadian.Application.Queries.MedicineQueries;
using PetGuadian.Application.Queries.PetQueries;
using PetGuardian.Domain.Repositories;

namespace PetGuadian.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            
            //Dependency Injections
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IMedicineRepository, MedicineRepository>();
            services.AddScoped<IVaccineRepository, VaccineRepository>();


            //PETHANDLERS
            // services.AddScoped<CreatePetHandler, CreatePetHandler>();
            // services.AddScoped<UpdatePetHandler, UpdatePetHandler>();
            // services.AddScoped<DeletePetHandler, DeletePetHandler>();
            //services.AddScoped<PetQueries, PetQueries>();
            //MEDIATR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));






            //PET
            services.AddTransient<IRequestHandler<CreatePetCommand, ICommandResult>, CreatePetHandler>();
            services.AddTransient<IRequestHandler<UpdatePetCommand, ICommandResult>, UpdatePetHandler>();
            services.AddTransient<IRequestHandler<DeletePetCommand, ICommandResult>, DeletePetHandler>();
            services.AddTransient<IRequestHandler<FindAllPetsByUserIdQuerie, ICommandResult>, PetQueries>();
            services.AddTransient<IRequestHandler<FindPetByIdQuerie, ICommandResult>, PetQueries>();

            //ADDRESS
            services.AddTransient<IRequestHandler<CreateAddressCommand, ICommandResult>, CreateAddressHandler>();
            services.AddTransient<IRequestHandler<GetAddressByIdQuerie, ICommandResult>, AddressQueries>();
            //USER
            services.AddTransient<IRequestHandler<CreateUserCommand, ICommandResult>, CreateUserHandler>();
            //EXAMS
            services.AddTransient<IRequestHandler<CreateExamCommand, ICommandResult>, CreateExamHandler>();
            //MEDICINES
            services.AddTransient<IRequestHandler<CreateMedicineCommand, ICommandResult>, CreateMedicineHandler>();
            services.AddTransient<IRequestHandler<DeleteMedicineCommand, ICommandResult>, DeleteMedicineHandler>();
            services.AddTransient<IRequestHandler<GetMedicineByIdQuerie, ICommandResult>, MedicineQueries>();
            //VACCINE
            services.AddTransient<IRequestHandler<CreateVaccineCommand, ICommandResult>, CreateVaccineHandler>();

            
            services.AddScoped<AppContextDb>();
        }
    }
}