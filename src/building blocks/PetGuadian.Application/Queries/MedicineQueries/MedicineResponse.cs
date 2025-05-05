using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuadian.Application.Queries.MedicineQueries
{
    public sealed record MedicineResponse(
        string RemedyName, 
        string Dosage, 
        string Observations, 
        DateTime StartDate, 
        DateTime? EndDate, 
        Guid PetId);
}