using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetGuardian.Domain.Core.Data;
using PetGuardian.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuadian.API.Data
{
    public class AppContextDb : DbContext, IUnityOfWork
    {
        public AppContextDb(DbContextOptions<AppContextDb> options) : base(options) { 
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<PetExams> Exams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //estas entidades não são para ser persistidas, devem ser ignoradas para não tentar realizar parse.
            modelBuilder.Ignore<ValidationResult>();
            

            //onde ouver relacionamento, desliga o cascade behaviour.
            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;


            //Mapeia a entidade de mapeamento
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppContextDb).Assembly);
        }

        public async Task<bool> Commit()
        {
            var success = await base.SaveChangesAsync() > 0;
            return success;
        }
    }
}