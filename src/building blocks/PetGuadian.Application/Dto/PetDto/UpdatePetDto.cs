using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuadian.Application.Dto.PetDto
{
    public record UpdatePetDto(
        Guid petId,
        Guid userId,
        string PetName, 
        char Gender, 
        DateTime BirthDate,
        float? Weight
    );
}