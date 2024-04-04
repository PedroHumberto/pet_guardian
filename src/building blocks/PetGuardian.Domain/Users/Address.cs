using PetGuardian.Core.PetGuardianCore.DomainObjects;

namespace PetGuardian.Domain.Users
{
    public record Address(string street,
            string number,
            string complement,
            string neighborhood,
            string city,
            string state,
            string postalCode);

}