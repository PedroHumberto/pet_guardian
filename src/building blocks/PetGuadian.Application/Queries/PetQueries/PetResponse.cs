using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetGuardian.Core.PetGuardianCore.Enums;

namespace PetGuadian.Application.Queries.PetQueries
{
    public record PetResponse(
        Guid Id,
        string PetName, 
        char Gender, 
        AnimalSpecies Specie,
        DateTime BirthDate,
        int? Age,
        float? Weight
        );
}