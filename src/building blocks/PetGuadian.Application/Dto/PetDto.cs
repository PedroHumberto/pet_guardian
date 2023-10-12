using PetGuardian.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetGuadian.Application.Dto
{
    public record PetDto(
        Guid Id,
        string PetName, 
        char Gender, 
        AnimalSpecies Specie,
        DateTime BirthDate,
        Guid UserId);
}
