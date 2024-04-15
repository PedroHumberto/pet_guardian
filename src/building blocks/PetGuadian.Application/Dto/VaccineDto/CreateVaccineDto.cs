using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuadian.Application.Dto.VaccineDto
{
    public record CreateVaccineDto(string name,
     DateTime vaccinatedAt,
     bool firstVaccin, 
     Guid petId, 
     string? notes);
}