using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetGuadian.Application.Dto.MedicineDto;
using PetGuardian.Core.PetGuardianCore.Enums;

namespace PetGuadian.Application.Dto.PetDto
{
    public record GetPetDto(
        Guid petId,
        string PetName, 
        char Gender, 
        AnimalSpecies Specie,
        DateTime BirthDate,
        int? Age,
        float? Weight
        );
}
