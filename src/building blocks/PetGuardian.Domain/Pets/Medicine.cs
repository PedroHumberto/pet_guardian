using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetGuardian.Core.PetGuardianCore.DomainObjects;

namespace PetGuardian.Domain.Pets
{
    public record Medicine(string remedyName, string dosage, string observations, DateTime startDate, DateTime? endDate);
   
}