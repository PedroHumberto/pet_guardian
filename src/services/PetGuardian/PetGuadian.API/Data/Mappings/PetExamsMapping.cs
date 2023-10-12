using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetGuardian.Models.Models;

namespace PetGuadian.API.Data.Mappings
{
    public class PetExamsMapping : IEntityTypeConfiguration<PetExams>
    {
        public void Configure(EntityTypeBuilder<PetExams> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.ExamLink)
                .IsRequired();

            builder.Property(e => e.ExamName)
                .IsRequired()
                .HasColumnType("varchar(40)");

            builder.HasOne(e => e.Pet)
                .WithMany(p => p.PetExams)
                .HasForeignKey(e => e.petId);
        }
    }
}
