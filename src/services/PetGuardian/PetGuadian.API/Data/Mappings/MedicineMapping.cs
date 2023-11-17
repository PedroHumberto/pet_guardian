using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetGuardian.Domain.Models;

namespace PetGuadian.API.Data.Mappings
{
    public class MedicineMapping : IEntityTypeConfiguration<Medicine>
    {
        public void Configure(EntityTypeBuilder<Medicine> builder)
        {
            builder.HasKey(m=> m.Id);

            builder.Property(m => m.RemedyName)
                .IsRequired()
                .HasColumnType("varchar(30)");
            builder.Property(m => m.Dosage)
                .IsRequired()
                .HasColumnType("varchar(40)");
            builder.Property(m => m.Observations)
                .IsRequired()
                .HasColumnType("nvarchar(max)");
        }
    }
}