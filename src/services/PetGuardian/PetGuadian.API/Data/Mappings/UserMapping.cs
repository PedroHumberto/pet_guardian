using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetGuardian.Core.PetGuardianCore.DomainObjects;
using PetGuardian.Models.Models;

namespace PetGuadian.API.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder) 
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name)
                .IsRequired()
                .HasColumnType("varchar(40)");

            builder.OwnsOne(u => u.Email, tf =>
            {
                tf.Property(u => u.EmailAddress)
                .IsRequired()
                .HasMaxLength(Email.EmailMaxLen)
                .HasColumnName("Email")
                .HasColumnType($"varchar({Email.EmailMaxLen})");
            });

            builder.HasMany(u => u.Pets)
                .WithOne(p => p.User);


            builder
                .HasOne(u => u.Address)  
                .WithOne()         
                .HasForeignKey<User>(u => u.AddressId);

            builder.ToTable("Users");
        }
    }
}
