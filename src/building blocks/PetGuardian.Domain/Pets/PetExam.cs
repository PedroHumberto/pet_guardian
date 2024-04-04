using PetGuardian.Core.PetGuardianCore.DomainObjects;

namespace PetGuardian.Domain.Pets
{
    public record PetExam(string examLink, string examName, DateTime examDate);

}