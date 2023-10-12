using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetGuardian.Models.Models;

namespace PetGuadian.API.Data.Mappings
{
    public class PetMapping : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder) 
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.PetName)
                .IsRequired()
                .HasColumnType("varchar(40)");

            builder.Property(p => p.Gender)
                .IsRequired()
                .HasColumnType("smallint");

            builder.HasOne(p => p.User)
                .WithMany(u => u.Pets);

            builder.HasMany(p => p.PetExams)
                .WithOne(e => e.Pet);

            builder.ToTable("Pets");

        }
    }
}
