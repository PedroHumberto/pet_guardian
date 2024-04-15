using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetGuardian.Domain.Models;

namespace PetGuadian.API.Data.Mappings
{
    public class PetExamsMapping : IEntityTypeConfiguration<PetExam>
    {
        public void Configure(EntityTypeBuilder<PetExam> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.ExamName)
                .IsRequired()
                .HasColumnType("varchar(40)");

            builder.Property(e => e.ExamLink)
                .IsRequired();
                
            builder.HasOne(e => e.Pet)
                .WithMany(p => p.PetExams)
                .HasForeignKey(e => e.PetId);
        }
    }
}
