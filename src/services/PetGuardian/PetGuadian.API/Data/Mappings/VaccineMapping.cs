using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetGuardian.Domain.Models;

namespace PetGuadian.API.Data.Mappings
{
    public class VaccineMapping : IEntityTypeConfiguration<Vaccine>
    {
        public void Configure(EntityTypeBuilder<Vaccine> builder)
        {
            builder.HasKey(v => v.Id);
            
            builder.Property(v => v.Name)
                .HasColumnType("varchar(40)");
            builder.Property(v => v.Notes)
                .HasColumnType("varchar(200)");

            builder.HasOne(v => v.Pet)
            .WithMany(p => p.Vaccines)
            .HasForeignKey(v => v.PetId)
            .OnDelete(DeleteBehavior.SetNull);

            builder.ToTable("Vaccines");
        }
    }
}