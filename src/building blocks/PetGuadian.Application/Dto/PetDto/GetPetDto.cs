using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetGuardian.Core.PetGuardianCore.Enums;

namespace PetGuadian.Application.Dto.PetDto
{
    public record GetPetDto(
        string PetName, 
        char Gender, 
        AnimalSpecies Specie,
        DateTime BirthDate,
        int? Age,
        long? Weight,
        Guid UserId);
}
