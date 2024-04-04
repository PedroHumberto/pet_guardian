using PetGuardian.Core.PetGuardianCore.DomainObjects;

namespace PetGuardian.Domain.Pets
{
    public record Vaccine(string name, DateTime vaccinatedAt, bool firstVaccin, string? notes);

}