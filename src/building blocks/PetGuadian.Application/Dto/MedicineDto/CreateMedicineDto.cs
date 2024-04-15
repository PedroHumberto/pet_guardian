using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuadian.Application.Dto.MedicineDto
{
    public record CreateMedicineDto(string RemedyName, string Dosage, string Observations, DateTime StartDate, DateTime? EndDate, Guid PetId);
}