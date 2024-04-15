using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuadian.Application.Dto.VaccineDto
{
    public record GetVaccineDto(Guid vaccineId, 
        Guid petId, string name, 
        DateTime vaccinatedAt, 
        bool firstVaccin, 
        string? notes);

}