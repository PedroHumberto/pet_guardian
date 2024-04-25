using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetGuardian.Domain.Models;

namespace PetGuadian.API.Data.Mappings
{
    public class VeterinarianMapping : IEntityTypeConfiguration<Veterinarian>
    {
        public void Configure(EntityTypeBuilder<Veterinarian> builder)
        {
            builder.HasKey(v => v.Id);

            builder.Property(v => v.FirstName)
            .HasColumnType("varchar(40)");

            builder.Property(v => v.SecondName)
            .HasColumnType("varchar(40)");

            builder.OwnsOne(v => v.CrvCode);

            builder.HasMany(v => v.PetSharedList)
            .WithMany(p => p.VeterinariansAllowed);

            builder.ToTable("Veterinarians");

            
        }
    }
}